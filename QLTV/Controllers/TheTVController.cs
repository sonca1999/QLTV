using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QLTV.Controllers
{
    using DLL;
    using Common.Req;
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;
    using QLTV.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class TheTVController : ControllerBase
    {
        public TheTVController()
        {
            _svc = new TheTVSvc();
        }

        [HttpPost("get-TheTV-by-id")]
        public IActionResult GetTheTVById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var thethuvien = _svc.GetTheTVById(req.Id);
            res.Data = thethuvien;
            return Ok(res);
        }

        [HttpPost("get-all-TheTV")]
        public IActionResult getAllTheTV()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }


        [HttpPost("create-TheTV")]
        public IActionResult CreateTheTV(TheTVReq req)
        {

            var res = _svc.CreateTheTV(req);
            return Ok(res);
        }
        [HttpPost("update-TheTV")]

        public IActionResult UpdateTheTV(TheTVReq req)
        {

            var res = _svc.UpdateTheTV(req);
            return Ok(res);
        }

        private readonly TheTVSvc _svc;
    }
}
