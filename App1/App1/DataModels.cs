using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    [Table("koordinate")]
    public class koordinate
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double latitude { get; set; }
        public double longtitude { get; set; }
        public int pot_id { get; set; }
    }

    [Table("poti")]
    public class poti
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string ime { get; set; }
    }

    [Table("zanimivosti")]
    public class tocke
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string ime { get; set; }
        public string opis { get; set; }
        public int pot_id { get; set; }
        public double vec_latitude { get; set; }
        public double majn_latitude { get; set; }
        public double vec_longtitude { get; set; }
        public double majn_longtitude { get; set; }
        public double latitude { get; set; }
        public double longtitude { get; set; }
        public int st_tocke { get; set; }
        public string audio { get; set; }
    }
}
