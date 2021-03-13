using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Models
{
    public class ResponseModel
    {
        [JsonProperty("events")]
        public List<EventModel> Events { get; set; }
    }
}
