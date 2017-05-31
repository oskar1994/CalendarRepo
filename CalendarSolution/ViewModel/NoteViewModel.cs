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
    public class NoteViewModel : ObservableObject , INotifyPropertyChanged
    {
        public NoteViewModel()
        {
            NoteDate = DateTime.Now.Date;
        }

        public event EventHandler<NoteEventArgs> NoteClosed;

        private ICommand cancelButtonCommand;
        private ICommand okButtonCommand;

        private DateTime noteDate;

        public DateTime NoteDate
        {
            get { return noteDate; }
            set
            {
                noteDate = value.Date;
                OnPropertyChanged(nameof(NoteDate));
            }
        }


        private string noteContent;
        public string NoteContent
        {
            get { return noteContent; }
            set
            {
                noteContent = value;
                OnPropertyChanged(nameof(NoteContent));
            }
        }


        private string noteName;
        public string NoteName
        {
            get { return noteName; }
            set
            {
                noteName = value;
                OnPropertyChanged(nameof(NoteName));
            }
        }


        private void OkButton()
        {
            if (NoteName != null && NoteContent != null)
            {
                try
                {
                    var note = new Model.Note()
                    {
                        Content = NoteName + "$" + noteContent,
                        Date = NoteDate
                    };
                    Controllers.NoteController.AddToNote(note);
                    OnNoteClosed(true);
                }
                catch (Exception exc)
                {
                }
            }
            else
            {
                OnNoteClosed(false);
            }
        }

        protected virtual void  OnNoteClosed(bool v)
        {
            if (NoteClosed != null)
            {
                NoteClosed(this, new NoteEventArgs() { IsClosed = v });
            }
        }

        private void CancelButton()
        {
            throw new NotImplementedException();
        }

        public ICommand OKButtonCommand
        {
            get
            {
                okButtonCommand = new RelayCommand<object>((x) => OkButton());
                return okButtonCommand;
            }
        }

        public ICommand CancelButtonCommand
        {
            get
            {
                cancelButtonCommand = new RelayCommand<object>((x) => CancelButton());
                return cancelButtonCommand;
            }
        }

    }
}
