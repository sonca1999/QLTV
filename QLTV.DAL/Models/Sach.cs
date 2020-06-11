using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTg { get; set; }
        public string MaTl { get; set; }
        public DateTime? NamSx { get; set; }

        public virtual Tacgia MaTgNavigation { get; set; }
        public virtual Theloai MaTlNavigation { get; set; }
    }
}
