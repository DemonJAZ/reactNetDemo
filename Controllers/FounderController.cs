using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using reactNetDemo.Model;
using Newtonsoft.Json;


namespace reactNetDemo.Controllers
{
    [ApiController]
    [Route("founder")]
    public class FounderController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var rng = new Founder();
            return JsonConvert.SerializeObject(rng);
        }
    }
}
