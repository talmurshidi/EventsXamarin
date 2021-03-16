using EventsXamarin.Helpers;
using EventsXamarin.Models;

using Plugin.Toast;
using Plugin.Toast.Abstractions;

using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.UI.Views;

namespace EventsXamarin.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
    {
        protected INavigationService NavigationService { get; private set; }

        public string Title { get; set; }
        public bool IsBusy { get; set; }
        public bool IsRefreshing { get; set; }
        public LayoutState CurrentState { get; set; }

        public bool IsInternetConnected()
        {
            var current = Xamarin.Essentials.Connectivity.NetworkAccess;
            if (current == Xamarin.Essentials.NetworkAccess.Internet)
                return true;

            return false;
        }

        public void ShowToastMessage(bool isSuccess, string message)
        {
            if (isSuccess)
                CrossToastPopUp.Current.ShowToastSuccess(message, ToastLength.Short);
            else
                CrossToastPopUp.Current.ShowToastError(message, ToastLength.Short);
        }

        public async Task<List<EventModel>> GetJsonData()
        {
            string jsonFileName = "events.json";
            ResponseModel objResponse = new ResponseModel();

            var assembly = typeof(ViewModelBase).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                objResponse = Utils.DeserializeObject<ResponseModel>(jsonString);
            }

            // Simulate waiting data
            await Task.Delay(TimeSpan.FromSeconds(2));

            return objResponse.Events;
        }

        public bool CanExecute()
        {
            if (CurrentState == LayoutState.Loading || IsBusy)
                return false;

            return true;
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public virtual void OnAppearing()
        {
            //OnAppearing
        }

        public virtual void OnDisappearing()
        {
            //OnDisappearing
        }
    }
}
