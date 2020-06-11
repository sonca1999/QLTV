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
    public class TheTVSvc : GenericSvc<TheTVRep, Thethuvien>
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

        public object GetTheTVById(int id)
        {
            var thethuvien = All.Where(x => x.MaThe == id)
                .Join(_rep.Context.Docgia, a => a.MaThe, b => b.MaThe, (a, b) => new
                {
                    a.MaThe,
                    a.NgayBd,
                    a.NgayHh,
                    Madocgia = b.MaDg,
                    Tendocgia =b.TenDg

                }).FirstOrDefault();
            
            return thethuvien;
        }

        
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public TheTVSvc() { }


        #endregion
        
        public SingleRsp CreateTheTV(TheTVReq thethuvien)
        {
            var res = new SingleRsp();
            Thethuvien Thethuvien = new Thethuvien();
            Thethuvien.MaThe = thethuvien.MaThe;
            Thethuvien.NgayBd = thethuvien.NgayBd;
            Thethuvien.NgayHh = thethuvien.NgayHh;
            res = _rep.CreateTheTV(Thethuvien);
            return res;
        }
        public SingleRsp UpdateTheTV(TheTVReq thethuvien)
        {
            var res = new SingleRsp();
            Thethuvien Thethuvien = new Thethuvien();
            Thethuvien.MaThe = thethuvien.MaThe;
            Thethuvien.NgayBd = thethuvien.NgayBd;
            Thethuvien.NgayHh = thethuvien.NgayHh;
            res = _rep.UpdateThethuvien(Thethuvien);
            return res;
        }

    }
}
