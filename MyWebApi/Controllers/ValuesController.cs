using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Entity1> Get()
        {
            IEnumerable<Entity1> items = null;
            using (var db = new MyProjectModelContainer())
            {
                // Create and save a new entity 
                var entity1 = new Entity1();
                db.Entity1.Add(entity1);
                db.SaveChanges();

                // Display all entities from the database 
                var query = from b in db.Entity1
                            orderby b.Id
                            select b;

                items = query.ToList();
            }

            return items;
        }
    }
}