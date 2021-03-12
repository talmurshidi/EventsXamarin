using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Models
{
    public class AddressModel : ModelBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
