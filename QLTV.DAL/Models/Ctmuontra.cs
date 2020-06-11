using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Ctmuontra
    {
        public int MaSach { get; set; }
        public int MaMt { get; set; }
        public bool DaTra { get; set; }
        public DateTime Ngaytra { get; set; }
        public string GhiChu { get; set; }

        public virtual Muontra MaMtNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
    }
}
