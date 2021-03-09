using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BASE.Models;
using LOGIC.DemoDataLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DemoDataController : ControllerBase
    {

        private DemoDataLogic demoDataLogic = new DemoDataLogic();


        // POST api/demodata/getDemoObjectWithProperties
        [HttpPost("getDemoObjectWithProperties")]
        public HttpResult Authenticate( [FromBody] DemoDataViewModel demoDataObj )
        {
            HttpResult result = demoDataLogic.GetDemoObjectWithProperties(demoDataObj.DemoDataObjectId);
            return result;
        }

        // POST api/demodata/getDemoObjects
        [HttpGet("getDemoObjects")]
        public HttpResult GetDemoObjects()
        {
            HttpResult result = demoDataLogic.GetDemoObjects();
            return result;
        }

        // POST api/demodata/AddDemoObject
        [HttpPost("AddDemoObject")]
        public HttpResult AddDemoObject(DemoDataViewModel demoObject)
        {
            HttpResult result = demoDataLogic.AddDemoObject(demoObject);
            return result;
        }

        // POST api/demodata/AddDemoProperties
        [HttpPost("AddDemoProperties")]
        public HttpResult AddDemoProperties(DemoDataPropertiesViewModel demoPropsObject)
        {
            HttpResult result = demoDataLogic.AddDemoProperties(demoPropsObject);
            return result;
        }

    }
}
