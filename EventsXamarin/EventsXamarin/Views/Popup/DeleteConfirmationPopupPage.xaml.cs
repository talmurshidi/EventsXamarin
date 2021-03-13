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

namespace EventsXamarin.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteConfirmationPopupPage : PopupPage
    {
        public DelegateCommand CancelBtnCommand { get; set; }
        public DelegateCommand DeleteBtnCommand { get; set; }

        public EventHandler<bool> DeleteAction;

        private async void CancelBtnAsync()
        {
            await ClosePopupAsync();
        }

        private async void DeleteBtnConfirmationAsync()
        {
            DeleteAction?.Invoke(this, true);
            await ClosePopupAsync();
        }

        private async Task ClosePopupAsync()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        public DeleteConfirmationPopupPage()
        {
            InitializeComponent();
            BindingContext = this;
            DeleteBtnCommand = new DelegateCommand(DeleteBtnConfirmationAsync);
            CancelBtnCommand = new DelegateCommand(CancelBtnAsync);
        }
    }
}