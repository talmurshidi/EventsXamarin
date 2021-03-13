using EventsXamarin.iOS.Renderers;

using Foundation;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using UIKit;

using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ContentPage), typeof(PageRenderer))]
namespace EventsXamarin.iOS.Renderers
{
    public class PageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                UpdateStatusBarColor();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private void UpdateStatusBarColor()
        {
            var bar = GetStatusBar();
            bar.BackgroundColor = ColorConverters.FromHex("#E64A19").ToPlatformColor();
        }

        private UIView GetStatusBar()
        {
            UIView statusBar;
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                int tag = 123; // Customize this tag as you want so we don't create it over and over
                UIWindow window = UIApplication.SharedApplication.Windows.FirstOrDefault();
                statusBar = window.ViewWithTag(tag);
                if (statusBar == null)
                {
                    statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame);
                    statusBar.Tag = tag;
                    statusBar.BackgroundColor = UIColor.Red; // Customize the view

                    window.AddSubview(statusBar);
                }
            }
            else
            {
                statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            }
            return statusBar;
        }
    }
}