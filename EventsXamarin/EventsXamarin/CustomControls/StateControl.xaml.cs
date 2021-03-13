using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsXamarin.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StateControl : ContentView
    {
        static StateControl Current;

        public static readonly BindableProperty CurrentStateProperty
            = BindableProperty.CreateAttached(
                nameof(CurrentState),
                typeof(LayoutState),
                typeof(Layout<View>),
                default(LayoutState),
                propertyChanged: (b, o, n) => OnCurrentStateChanged(b, (LayoutState)o, (LayoutState)n));

        private static void OnCurrentStateChanged(BindableObject bindable, LayoutState oldValue, LayoutState newValue)
        {
            if (newValue == LayoutState.None)
                Current.IsVisible = false;
            else
                Current.IsVisible = true;
        }

        public LayoutState CurrentState
        {
            get => (LayoutState)GetValue(CurrentStateProperty);
            set => SetValue(CurrentStateProperty, value);
        }

        public StateControl()
        {
            InitializeComponent();
            Current = this;
        }
    }
}