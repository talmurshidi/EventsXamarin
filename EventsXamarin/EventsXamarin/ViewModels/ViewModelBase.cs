using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EventsXamarin.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
    {
        protected INavigationService NavigationService { get; private set; }

        public string Title { get; set; }
        public bool IsBusy { get; set; }
        public bool IsRefreshing { get; set; }

        public bool IsInternetConnected()
        {
            var current = Xamarin.Essentials.Connectivity.NetworkAccess;
            if (current == Xamarin.Essentials.NetworkAccess.Internet)
                return true;

            return false;
        }

        public bool CanExecute()
        {
            return !IsBusy;
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

        public void OnAppearing()
        {
            //OnAppearing
        }

        public void OnDisappearing()
        {
            //OnDisappearing
        }
    }
}
