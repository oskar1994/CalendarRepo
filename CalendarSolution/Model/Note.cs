using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution.Model
{
    [Table(Name= "CalendarDb")]
    public class Note
    {
        [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false)]
        public int Id { get; set; }
        [Column(CanBeNull = true)]
        public string Content { get; set; }
        [Column(CanBeNull = false)]
        public DateTime Date { get; set; }
    }
}
