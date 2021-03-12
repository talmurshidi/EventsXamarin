using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Models
{
    public class EventModel : ModelBase
    {
        public string Title { get; set; }
        public string Descritpion { get; set; }
        public DateTime Date { get; set; }
        public bool IsAttended { get; set; }
        public AddressModel Address { get; set; }
        public List<AttendanceModel> AttendanceList { get; set; }
    }
}
