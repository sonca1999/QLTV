using QLTV.Common.DAL;
using System.Linq;
using System;

namespace QLTV.DAL
{
    using Models;
    using QLTV.Common.Rsp;
    using System.Drawing;
    public class DocGiaRep : GenericRep<QLTVContext, Docgia>
    {

        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Docgia Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaDg == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaDg == id);
            m = base.Delete(m); //TODO
            return m.MaDg;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SingleRsp CreateDocgia(Docgia docgia)
        {
            var res = new SingleRsp();
            using (var context = new QLTVContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Docgia.Add(docgia);
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
        public SingleRsp UpdateDocgia(Docgia docgia)
        {
            var res = new SingleRsp();
            using (var context = new QLTVContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Docgia.Update(docgia);
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
