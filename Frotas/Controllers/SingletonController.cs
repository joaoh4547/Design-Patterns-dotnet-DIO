using Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        private readonly SingletonContainer _singletonContainer;
        public SingletonController(SingletonContainer singletonContainer)
        {
            _singletonContainer = singletonContainer;
        }

        [HttpGet]
        public IActionResult Get()
        {
           
            return Ok(_singletonContainer);
        }
    }
}
    