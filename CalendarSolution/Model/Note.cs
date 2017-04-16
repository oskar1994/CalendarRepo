using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution.Model
{
    public class Note
    {
        public Note()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Content;
        public DateTime Date;

    }
}
