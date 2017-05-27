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
            Random rnd = new Random();
            Note.Id = rnd.Next(30000);
            foreach (var note in allNotes)
            {
                if (note.Id.Equals(Note.Id))
                {
                    Note.Id = rnd.Next(30000);
                }
            }
            SQLData.SQLDataContext.Notes.InsertOnSubmit(Note);
            SQLData.SQLDataContext.Database.SubmitChanges();
        }
        public static Model.Note GetNote(DateTime Date){
            var note = SQLData.SQLDataContext.Notes.Where(x => x.Date == Date).FirstOrDefault();
            if (note != null)
                return note;
            else return null;
            }

    }
}
