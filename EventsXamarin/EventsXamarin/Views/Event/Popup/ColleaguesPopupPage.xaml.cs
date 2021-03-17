using EventsXamarin.Models;

using Prism.Commands;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsXamarin.Views.Event.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColleaguesPopupPage : PopupPage
    {
        public List<AttendanceModel> Attendance { get; set; }
        public DelegateCommand CloseCommand { get; set; }

        private async void ClosePopupAsync()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        public ColleaguesPopupPage(List<AttendanceModel> attendanceModels)
        {
            InitializeComponent();
            BindingContext = this;
            Attendance = attendanceModels;
            CloseCommand = new DelegateCommand(ClosePopupAsync);
        }
    }
}