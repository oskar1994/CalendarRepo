using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalendarSolution.ViewModel 
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public CalendarViewModel()
        {
            Date = DateTime.Now;
            //Model.Note newNote = new Model.Note() { Id = 1, Date = DateTime.Now, Content = "lala" };
            //Controllers.NoteController.AddToNote(newNote);
            //var allNotes = SQLData.SQLDataContext.Notes.ToList();
        }
        #endregion

        #region Fields
        private ICommand nextButtonCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime _date;
        #endregion

        #region Properties
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
        #endregion

        #region Methods
        private void NextButton()
        {
            Date = Date.AddDays(1);
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

        #region Commands

        public ICommand NextButtonCommand
        {
            get
            {
            nextButtonCommand = new RelayCommand<object>((x) => NextButton());
            return nextButtonCommand;
            }
        }

        #endregion

    }
}
