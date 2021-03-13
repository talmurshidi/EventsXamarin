using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Models
{
    public class EventModel : ModelBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("from_time")]
        public TimeSpan FromTime { get; set; }

        [JsonProperty("to_time")]
        public TimeSpan ToTime { get; set; }

        [JsonProperty("is_attended")]
        public bool IsAttended { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("address")]
        public AddressModel Address { get; set; }

        [JsonProperty("attendance")]
        public List<AttendanceModel> AttendanceList { get; set; }
    }
}
