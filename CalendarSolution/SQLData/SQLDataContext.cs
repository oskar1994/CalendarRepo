    using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution.SQLData
{
    public static class SQLDataContext
    {
       
       private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CalendarDb.mdf;Integrated Security=True";
       public static DataContext Database = new DataContext(connectionString);
       public static Table<Model.Note> Notes = Database.GetTable<Model.Note>();
    }
}
