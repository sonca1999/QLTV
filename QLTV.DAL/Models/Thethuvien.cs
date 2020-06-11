using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Thethuvien
    {
        public Thethuvien()
        {
            Docgia = new HashSet<Docgia>();
            Muontra = new HashSet<Muontra>();
        }

        public int MaThe { get; set; }
        public DateTime NgayBd { get; set; }
        public DateTime NgayHh { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Docgia> Docgia { get; set; }
        public virtual ICollection<Muontra> Muontra { get; set; }
    }
}
