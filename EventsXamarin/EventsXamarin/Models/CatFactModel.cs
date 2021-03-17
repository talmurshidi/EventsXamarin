using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Models
{
    public class CatFactModel : ModelBase
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
