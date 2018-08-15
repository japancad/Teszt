using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPhotosWithIdentity.Data;
using FamilyPhotosWithIdentity.Models.Github;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FamilyPhotosWithIdentity.Controllers.api
{

    // http://requestbin.fullcontact.com/1isv82z1
    [Produces("application/json")]
    [Route("api/WebHook")]   //?api/github
    
    public class WebHookController : Controller
    {

        //atveszük ef-et contextjet
        private readonly ApplicationDbContext db;

        public WebHookController(ApplicationDbContext db)
        {
            this.db = db;
        }
        //Ideig tart az átvétel 


        [HttpPost]
        public IActionResult Post()
        {
            var length = HttpContext.Request.ContentLength;
            if (int.MaxValue<length)
            {
                throw new ArgumentOutOfRangeException($"Túl hosszú a kérés: {length} ");
            }

            var buffer = new byte[(int)HttpContext.Request.ContentLength];
            var count = HttpContext.Request.Body.Read(buffer,0, (int)length);

            if (count!=(int)length)
            {
                throw new Exception($"Hiba van : {count}");
            }

            var payload = Encoding.UTF8.GetString(buffer);


            if (payload != null)
            {
                var request = JsonConvert.DeserializeObject<GithubRequest>(payload);
                if (request != null)
                {
                    //Hozzáadás adatbázishoz
                    db.GithubRequests.Add(request);
                    db.SaveChanges();
                }
            }

            return Ok();
        }

    }
}