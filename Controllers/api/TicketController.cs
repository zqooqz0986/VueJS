using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VueJS.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Buy([FromBody]string value)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("htt0....");
            }
        }

    }
}
