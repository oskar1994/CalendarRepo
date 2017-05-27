﻿using CalendarSolution.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CalendarSolution.ViewModel 
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public CalendarViewModel()
        {
            Date = DateTime.Now;
           // Model.Note newNote = new Model.Note() { Id = 1, Date = DateTime.Now, Content = "lala" };
           //Controllers.NoteController.AddToNote(newNote);
           // var allNotes = SQLData.SQLDataContext.Notes.ToList();
        }
        #endregion

        #region Fields
        private ICommand nextButtonCommand;
        private ICommand previousButtonCommand;
        private ICommand addNoteButtonCommand;
        private ICommand closeApplicationbuttonCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime _date;
        NoteViewModel NoteVM { get; set; }
        NoteView NoteV { get; set; }
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

        private void PreviousButton()
        {
            Date = Date.AddDays(-1);
        }

        private void AddNoteButton()
        {
            NoteV = new NoteView();
            NoteVM = new NoteViewModel();
            NoteV.DataContext = NoteVM;
            NoteVM.NoteClosed += OnNoteClosed;
            NoteV.Show();

           
        }

        public void OnNoteClosed(object source, NoteEventArgs args)
        {
            switch (args.IsClosed)
            {
                case true:
                    {
                        NoteV.Close();
                    }
                    break;
                case false:                   
                    break;
            }
        }

        private void CloseApplicationbutton()
        {
            Application.Current.Shutdown();
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
        public ICommand PreviousButtonCommand
        {
            get
            {
                previousButtonCommand = new RelayCommand<object>((x) => PreviousButton());
                return previousButtonCommand;
            }
        }

        public ICommand AddNoteButtonCommand
        {
            get
            {
                addNoteButtonCommand = new RelayCommand<object>((x) => AddNoteButton());
                return addNoteButtonCommand;
            }
        }

        public ICommand CloseApplicationbuttonCommand
        {
            get
            {
                closeApplicationbuttonCommand = new RelayCommand<object>((x) => CloseApplicationbutton());
                return closeApplicationbuttonCommand;
            }
        }



        #endregion

    }
}
