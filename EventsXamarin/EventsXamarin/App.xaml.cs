using EventsXamarin.AppResources.Localizations;
using EventsXamarin.Helpers;
using EventsXamarin.ViewModels;
using EventsXamarin.Views;
using EventsXamarin.Views.Event;

using Prism;
using Prism.Ioc;

using System.Globalization;
using System.Threading;

using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace EventsXamarin
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            Xamarin.Essentials.VersionTracking.Track();
            AppLanguage();

            await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(EventsPage));
        }

        protected void AppLanguage()
        {
            var cultureInfo = new CultureInfo(Constants.EnglishLang, false)
            {
                DateTimeFormat = DateTimeFormatInfo.InvariantInfo
            };

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

            Lang.Culture = new CultureInfo(Constants.EnglishLang);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<EventsPage, EventsPageViewModel>();
        }


    }
}
