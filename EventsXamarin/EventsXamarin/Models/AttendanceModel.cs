﻿using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Models
{
    public class AttendanceModel : ModelBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
