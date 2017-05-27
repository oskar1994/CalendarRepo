﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalendarSolution.ViewModel
{
    public class NoteViewModel : ObservableObject
    {

        private ICommand cancelButtonCommand;
        private ICommand okButtonCommand;

        private void OkButton()
        {
            throw new NotImplementedException();
        }

        private void CancelButton()
        {
            throw new NotImplementedException();
        }

        public ICommand OkButtonCommand
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
