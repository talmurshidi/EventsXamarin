using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EventsXamarin.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
