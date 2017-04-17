using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution.ViewModel
{
    class CalendarViewModel : INotifyPropertyChanged
    {
        #region Field
        public event PropertyChangedEventHandler PropertyChanged; 
        private DateTime _date; //Pole zawierające Datę
        #endregion


        #region Methods
        public DateTime Date //Publiczna właściwość Date dla _date
        {
            get { return _date; }
            set
            {
                if (value != null && value != _date)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        protected void OnPropertyChanged(string Label)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(Label));
            }
        }
        #endregion
    }
}
