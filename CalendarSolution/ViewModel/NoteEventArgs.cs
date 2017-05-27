using System;

namespace CalendarSolution.ViewModel
{
    public class NoteEventArgs : EventArgs
    {
        public bool IsClosed { get; set; }
    }
}