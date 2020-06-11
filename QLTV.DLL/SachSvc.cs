using Newtonsoft.Json;

using QLTV.DLL;
using QLTV.Common.Rsp;
using QLTV.Common.DLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTV.DLL
{
    using DAL;
    using Models;
    using QLTV.Common.Req;

    public class SachSvc : GenericSvc<SachRep, Sach>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public object GetSachById(int id)
        {
            var sach = All.Where(x => x.MaSach == id)
                .Join(_rep.Context.Theloai, a => a.MaTl, b => b.MaTl, (a, b) => new
                {
                    a.MaSach,
                    a.MaTg,
                    a.TenSach,
                    a.NamSx,
                    TenTheLoai = b.TenTl

                })
                .Join(_rep.Context.Tacgia, a => a.MaTg, b => b.MaTg, (a, b) => new
                {
                    a.MaSach,
                    a.MaTg,
                    a.TenSach,
                    a.NamSx,
                    a.TenTheLoai,
                    TenTacGia = b.TenTg

                }).FirstOrDefault();
            return sach;
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(Sach m)
        {
            var res = new SingleRsp();

            var m1 = m.MaSach > 0 ? _rep.Read(m.TenSach) : _rep.Read(m.MaSach);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SachSvc() { }


        #endregion


        /// <summary>
        /// Search Sach
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return list sach</returns>
        public object SearchSach(string keyword, int page, int size)
        {
            var sach = All.Where(x => x.TenSach.Contains(keyword));
            var offset = (page - 1) * size;
            var total = sach.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = sach.OrderBy(x => x.TenSach).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = page,
                Size = size


            };
            return res;
        }
        public SingleRsp CreateSach(SachReq sach)
        {
            var res = new SingleRsp();
            Sach Sach = new Sach();
            Sach.MaSach = sach.MaSach;
            Sach.TenSach = sach.TenSach;
            Sach.MaTg = sach.MaTg;
            Sach.MaTl = sach.MaTl;
            Sach.NamSx = sach.NamSx;
            res = _rep.CreateSach(Sach);
            return res;
        }
        public SingleRsp UpdateSach(SachReq sach)
        {
            var res = new SingleRsp();
            Sach Sach = new Sach();
            Sach.MaSach = sach.MaSach;
            Sach.TenSach = sach.TenSach;
            Sach.MaTg = sach.MaTg;
            Sach.MaTl = sach.MaTl;
            Sach.NamSx = sach.NamSx;
            res = _rep.UpdateSach(Sach);
            return res;
        }

        
    }
}
    

