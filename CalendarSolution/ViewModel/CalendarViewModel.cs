using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalendarSolution.ViewModel 
{
    class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime _date;
        public event PropertyChangedEventHandler PropertyChanged;


        private ICommand nextButtonCommand;
        

        private void NextButton()
        { Date = Date.AddDays(1); }
        
        public ICommand NextButtonCommand
        {
            get
            { nextButtonCommand = new RelayCommand<object>((x) => NextButton());
            return nextButtonCommand; }
            }

        

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
