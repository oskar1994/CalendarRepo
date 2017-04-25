using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution.Controllers
{
    public static class NoteController
    {
        public static void AddToNote(Model.Note Note)
        {
            var allNotes = SQLData.SQLDataContext.Notes;
            foreach(var note in allNotes)
            {
                if (note.Id.Equals(Note.Id))
                {
                    throw new Exception("Note with that Id already exists.");
                }
            }
            SQLData.SQLDataContext.Notes.InsertOnSubmit(Note);
            SQLData.SQLDataContext.Database.SubmitChanges();
        }
    }
}
