using QLTV.Common.DAL;
using System.Linq;
using System;

namespace QLTV.DAL
{
    using Models;
    using QLTV.Common.Rsp;
    using System.Drawing;

    public class TheTVRep : GenericRep<QLTVContext, Thethuvien>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Thethuvien Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaThe == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaThe == id);
            m = base.Delete(m); //TODO
            return m.MaThe;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SingleRsp CreateTheTV(Thethuvien thethuvien)
        {
            var res = new SingleRsp();
            using (var context = new QLTVContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Thethuvien.Add(thethuvien);
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
        public SingleRsp UpdateThethuvien(Thethuvien thethuvien)
        {
            var res = new SingleRsp();
            using (var context = new QLTVContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Thethuvien.Update(thethuvien);
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
        public object Delete(int id)
        {
            //Tìm dữ liệu theo id
            var searchResult = Context.Thethuvien.FirstOrDefault(value => value.MaThe== id);
            try
            {
                if (searchResult != null)
                {
                    Context.Remove(searchResult);
                    Context.SaveChanges();
                    return searchResult;
                }
                else
                {
                    return "Unable to delete: not found ID.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
        #endregion
    }
}
