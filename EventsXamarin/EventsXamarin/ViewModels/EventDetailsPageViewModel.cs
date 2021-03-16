using EventsXamarin.AppResources.Localizations;
using EventsXamarin.Models;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;

namespace EventsXamarin.ViewModels
{
    public class EventDetailsPageViewModel : ViewModelBase
    {
        public DelegateCommand AttendBtnCommand { get; set; }
        public DelegateCommand<AddressModel> OpenMapCommand { get; set; }
        public EventModel Event { get; set; }
        public bool IsAttended { get; set; }

        private async void AttendUserAsync()
        {
            CurrentState = LayoutState.Loading;
            await Task.Delay(TimeSpan.FromSeconds(2));

            var attendanceList = Event.AttendanceList;
            attendanceList.Add(new AttendanceModel { Id = "7723", Name = "Tamer" });
            Event.AttendanceList = null;
            Event.AttendanceList = attendanceList;
            Event.IsAttended = true;
            IsAttended = Event.IsAttended;

            CurrentState = LayoutState.None;
        }

        private async void OpenMapAsync(AddressModel addressModel)
        {
            if (addressModel == null) return;

            var location = new Location(47.645160, -122.1306032);

            try
            {
                await Map.OpenAsync(location);
            }
            catch (Exception ex)
            {
                // No map application available to open
                ShowToastMessage(false, Lang.No_App_Map_Avilable_Message);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("EventDetails"))
            {
                Event = parameters.GetValue<EventModel>("EventDetails");
                IsAttended = Event.IsAttended;
            }
        }

        public EventDetailsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            AttendBtnCommand = new DelegateCommand(AttendUserAsync, CanExecute);
            OpenMapCommand = new DelegateCommand<AddressModel>(OpenMapAsync);
        }
    }
}
