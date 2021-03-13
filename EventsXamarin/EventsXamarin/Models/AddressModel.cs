using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Models
{
    public class AddressModel : ModelBase
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
