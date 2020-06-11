using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Sach = new HashSet<Sach>();
        }

        public string MaTl { get; set; }
        public string TenTl { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
