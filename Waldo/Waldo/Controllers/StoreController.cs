using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Waldo.Service;
using Waldo.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Waldo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        StoreService MyService = new StoreService();

        // GET: api/values
        [EnableCors("TestPolicy")]
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            return MyService.GetStores();
        }

        // GET api/values/5
        [EnableCors("TestPolicy")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Store myStore = MyService.GetStore(id);
            if (myStore == null)
            {
                return "No Store with that Id";
            }
            else
            {
                return "Name: " + myStore.Name + " Address: " + myStore.Address;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
