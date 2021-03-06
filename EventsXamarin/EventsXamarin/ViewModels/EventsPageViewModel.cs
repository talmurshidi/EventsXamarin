using EventsXamarin.AppResources.Localizations;
using EventsXamarin.Helpers;
using EventsXamarin.Models;
using EventsXamarin.Views.CatFact;
using EventsXamarin.Views.Event;
using EventsXamarin.Views.Popup;

using Plugin.Toast;
using Plugin.Toast.Abstractions;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using Rg.Plugins.Popup.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.UI.Views;

namespace EventsXamarin.ViewModels
{
    public class EventsPageViewModel : ViewModelBase
    {
        public ObservableCollection<EventModel> Events { get; set; }
        public DelegateCommand<EventModel> DeleteCommand { get; set; }
        public DelegateCommand GetEventsCommand { get; set; }
        public DelegateCommand NavCatFactCommand { get; set; }
        public DelegateCommand<EventModel> EventDetailsCommand { get; set; }

        private async void OpenDeletePopupAsync(EventModel obj)
        {
            if (obj == null) return;

            var deleteConfirmationPopup = new DeleteConfirmationPopupPage();

            deleteConfirmationPopup.DeleteAction += async (sender, isDelete) =>
            {
                if (isDelete)
                {
                    await DeleteEventAsync(obj);
                }
            };

            await PopupNavigation.Instance.PushAsync(deleteConfirmationPopup);
        }

        private async Task DeleteEventAsync(EventModel obj)
        {
            CurrentState = LayoutState.Loading;

            //Simulate waiting process
            await Task.Delay(TimeSpan.FromSeconds(2));

            var isDeleted = Events.Remove(obj);

            CurrentState = LayoutState.None;

            var message = isDeleted ? Lang.Delete_Success_Message_Toast : Lang.Delete_Error_Message_Toast;
            ShowToastMessage(isDeleted, message);
        }

        private async void RefreshEventsAsync()
        {
            IsRefreshing = true;
            await LoadEventsAsync();
            IsRefreshing = false;
        }

        private async Task LoadEventsAsync()
        {
            var eventsData = await GetJsonData();
            Events = new ObservableCollection<EventModel>(eventsData);
        }

        private async void EventDetailsAsync(EventModel eventModel)
        {
            if (eventModel == null) return;

            var navParameter = new NavigationParameters();
            navParameter.Add(Constants.EventDetails, eventModel);

            await NavigationService.NavigateAsync(nameof(EventDetailsPage), navParameter);
        }

        private async void NavigateToCatFactsPageAsync()
        {
            await NavigationService.NavigateAsync(nameof(CatFactsPage));
        }

        public async override void OnAppearing()
        {
            if (Events == null)
            {
                CurrentState = LayoutState.Loading;
                await LoadEventsAsync();
                CurrentState = LayoutState.None;
            }
        }

        public EventsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Lang.Event_Title;
            DeleteCommand = new DelegateCommand<EventModel>(OpenDeletePopupAsync);
            GetEventsCommand = new DelegateCommand(RefreshEventsAsync);
            EventDetailsCommand = new DelegateCommand<EventModel>(EventDetailsAsync);
            NavCatFactCommand = new DelegateCommand(NavigateToCatFactsPageAsync);
        }
    }
}
