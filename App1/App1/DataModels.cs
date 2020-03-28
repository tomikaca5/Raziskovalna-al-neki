using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    [Table("avtobusna_scv")]
    public class avtobusna
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double langtitude { get; set; }
        public double longtitude { get; set; }
    }
}
