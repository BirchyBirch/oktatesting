using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace okta_experiments.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(IConfiguration values)
        {
            Values = values;
        }

        public IConfiguration Values { get; }


        // GET api/values/secure
        [Authorize]
        [HttpGet]
        [Route("secure")]
        public ActionResult<IEnumerable<string>> GetSecure()
        {
            var section = Values.GetSection("ReturnValues");
            var data= new List<string>();
            section.Bind(data);
            return data;
        }

        // GET api/values/insecure
        [AllowAnonymous]
        [HttpGet]
        [Route("insecure")]
        public ActionResult<IEnumerable<string>> GetInsecure()
        {
            var section = Values.GetSection("ReturnValues_IN");
            var data = new List<string>();
            section.Bind(data);
            return data;
        }
    }
}
