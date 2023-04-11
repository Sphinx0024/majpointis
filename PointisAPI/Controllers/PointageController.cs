using PointisAPI.Models;
using PointisData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PointisAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PointageController : ApiController
    {
        // GET: api/Pointage
        [HttpGet]
        public IEnumerable<Pointage> Get()
        {
            return PointageModel.afficher();
        }

        // GET: api/Pointage/5
        [HttpGet]
        public IEnumerable<Pointage> Get(long id)
        {
            return PointageModel.AfficherUnSeul(id);
        }

        // POST: api/Pointage
        [HttpPost]
        public void Post([FromBody]Pointage pointage)
        {
            PointageModel.Ajouter(pointage);
        }

        // PUT: api/Pointage/5
        [HttpPut]
        public void Put(long id, [FromBody] Pointage pointage)
        {
            PointageModel.Modifier(id, pointage);
        }

        // DELETE: api/Pointage/5
        [HttpDelete]
        public void Delete(long id)
        {
            PointageModel.supprimer(id);
        }
    }
}
