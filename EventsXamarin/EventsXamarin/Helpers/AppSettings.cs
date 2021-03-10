using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Essentials;

namespace EventsXamarin.Helpers
{
    public static class AppSettings
    {
        public static string Email
        {
            get
            {
                return Preferences.Get(nameof(Email), string.Empty);
            }
            set
            {
                Preferences.Set(nameof(Email), value);
            }
        }
    }
}
