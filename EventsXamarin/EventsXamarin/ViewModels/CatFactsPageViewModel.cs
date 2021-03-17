using EventsXamarin.AppResources.Localizations;
using EventsXamarin.Helpers;
using EventsXamarin.Models;
using EventsXamarin.Rest;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.UI.Views;

namespace EventsXamarin.ViewModels
{
    public class CatFactsPageViewModel : ViewModelBase
    {
        public ObservableCollection<CatFactModel> CatFacts { get; set; }
        public DelegateCommand RefreshCatFactsCommand { get; set; }
        readonly ApiService GetApiService;

        private async Task GetCatFactsAsync()
        {
            if (IsInternetConnected())
            {
                CurrentState = LayoutState.Loading;

                var response = await GetApiService.CatFactsAsync();

                CurrentState = LayoutState.None;

                if (response.Key == Constants.Success)
                {
                    CatFacts = new ObservableCollection<CatFactModel>(response.Value);
                }
                else
                {
                    ShowToastMessage(false, Lang.General_Error_Message);
                }
            }
        }

        private async Task RefreshCatFactsAsync()
        {
            IsRefreshing = true;
            await GetCatFactsAsync();
            IsRefreshing = false;
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();

            if (CatFacts == null)
                await GetCatFactsAsync();
        }

        public CatFactsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Lang.Cat_Facts_Title;
            GetApiService = new ApiService();
            RefreshCatFactsCommand = new DelegateCommand(async () => await RefreshCatFactsAsync());
        }
    }
}
