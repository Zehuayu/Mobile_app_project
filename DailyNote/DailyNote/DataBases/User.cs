using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyNote.DataBases
{
    [Table("User")]
    class User
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public String Password { get; set; }


      
    }
}
