using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EventsXamarin.Helpers
{
    public static class Utils
    {
        public static T DeserializeObject<T>(string stringContent)
        {
            return JsonConvert.DeserializeObject<T>(stringContent, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Culture = CultureInfo.InvariantCulture,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            });
        }
    }
}
