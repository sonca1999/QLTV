using QLTV.Common.DAL;
using System.Linq;
using System;

namespace QLTV.DAL
{
    using Models;
    using QLTV.Common.Rsp;
    using System.Drawing;

    public class SachRep : GenericRep<QLTVContext, Sach>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Sach Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaSach == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaSach == id);
            m = base.Delete(m); //TODO
            return m.MaSach;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SingleRsp CreateSach(Sach sach)
        {
            var res = new SingleRsp();
            using(var context = new QLTVContext())
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Sach.Add(sach);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateSach(Sach sach)
        {
            var res = new SingleRsp();
            using (var context = new QLTVContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Sach.Update(sach);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;


            
            }
        #endregion
    }
}
