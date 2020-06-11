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
    public class DocGiaSvc : GenericSvc<DocGiaRep, Docgia>
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

        public object GetDocGiaById(int id)
        {
            var docgia = All.Where(x => x.MaDg == id)
                .Join(_rep.Context.Thethuvien, a => a.MaThe, b => b.MaThe, (a, b) => new
                {
                    a.MaDg,
                    a.TenDg,
                    a.Sdt,
                    NgayHetHan = b.NgayHh,
                    NgayBatDau = b.NgayBd

                }).FirstOrDefault();

            return docgia;
        }


        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public DocGiaSvc() { }


        #endregion

        /// <summary>
        /// Search DocGia
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return list docgia</returns>
        public object SearchDocGia(string keyword, int page, int size)
        {
            var sach = All.Where(x => x.TenDg.Contains(keyword));
            var offset = (page - 1) * size;
            var total = sach.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = sach.OrderBy(x => x.TenDg).Skip(offset).Take(size).ToList();
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

        public SingleRsp CreateDocGia(DocGiaReq docgia)
        {
            var res = new SingleRsp();
            Docgia Docgia = new Docgia();
            Docgia.MaDg = Docgia.MaDg;
            Docgia.TenDg = docgia.TenDg;
            Docgia.Sdt = docgia.Sdt;
            res = _rep.CreateDocgia(Docgia);
            return res;
        }
        public SingleRsp UpdateDocGia(DocGiaReq docgia)
        {
            var res = new SingleRsp();
            Docgia Docgia = new Docgia();
            Docgia.MaDg = Docgia.MaDg;
            Docgia.TenDg = docgia.TenDg;
            Docgia.Sdt = docgia.Sdt;
            res = _rep.UpdateDocgia(Docgia);
            return res;
        }
    }
}
