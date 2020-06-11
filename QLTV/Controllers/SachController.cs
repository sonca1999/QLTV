using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QLTV.Web.Controllers
{
    using DLL;
    using Common.Req;
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;
    using QLTV.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        public SachController()
        {
            _svc = new SachSvc();
        }

        [HttpPost("get-Sach-by-id")]
        public IActionResult GetSachById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var sach = _svc.GetSachById(req.Id);
            res.Data = sach;
            return Ok(res);
        }

        [HttpPost("get-all-Sach")]
        public IActionResult getAllSach()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }


        [HttpPost("Search-Sach")]
        public IActionResult SearchSach([FromBody] SearchSachReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchSach(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }


        [HttpPost("create-sach")]
        public IActionResult CreateSach(SachReq req)
        {
            
            var res = _svc.CreateSach(req);
            return Ok(res);
        }
        [HttpPost("update-sach")]
        public IActionResult UpdateSach(SachReq req)
        {

            var res = _svc.UpdateSach(req);
            return Ok(res);
        }

        private readonly SachSvc _svc;
    }
}
