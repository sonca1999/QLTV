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
    public class DocGiaController : ControllerBase
    {
        public DocGiaController()
        {
            _svc = new DocGiaSvc();
        }

        [HttpPost("get-DocGia-by-id")]
        public IActionResult GetDocGiaById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var docgia = _svc.GetDocGiaById(req.Id);
            res.Data = docgia;
            return Ok(res);
        }

        [HttpPost("get-all-DocGia")]
        public IActionResult getAllDocGia()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }


        [HttpPost("Search-DocGia")]
        public IActionResult SearchDocGia([FromBody] SearchSachReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchDocGia(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }


        [HttpPost("create-DocGia")]
        public IActionResult CreateDocGia(DocGiaReq req)
        {

            var res = _svc.CreateDocGia(req);
            return Ok(res);
        }
        [HttpPost("update-DocGia")]
        public IActionResult UpdateDocGia(DocGiaReq req)
        {

            var res = _svc.UpdateDocGia(req);
            return Ok(res);
        }

        private readonly DocGiaSvc _svc;
    }
}
