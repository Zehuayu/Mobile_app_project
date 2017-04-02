using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyNote.DataBases
{


    [Table("note")]
    class note
    {

        
        [PrimaryKey]
        [AutoIncrement]
        public int Id{ get; set; }

        public String Info { get; set; }

        public String Location { get; set; }

        public DateTime Time { get; set; }


    }
}

