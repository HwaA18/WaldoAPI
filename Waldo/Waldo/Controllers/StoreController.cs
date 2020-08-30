using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Waldo.Service;
using Waldo.Entity;

namespace Waldo.Controllers
{
    //Route sets so that the url matches https://waldofind.azurewebsites.net/store
    [Route("[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        //Established our StoreService which communicates with our SQL database
        StoreService MyService = new StoreService();

        // GET
        //Needed the TestPolicy for Cors when running localhost tests
        [EnableCors("TestPolicy")]
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            //Returns a list of all the stores we have info on in the database
            return MyService.GetStores();
        }

        // GET /get/5
        //Needed the TestPolicy for Cors when running localhost tests
        [EnableCors("TestPolicy")]
        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            //Gets the store from our database with the store id entered
            Store myStore = MyService.GetStore(id);
            //Displays a no store message if it does not exist
            if (myStore == null)
            {
                return "No Store with that Id";
            }
            //Displays the store's name and address if it exists
            else
            {
                return "Name: " + myStore.Name + " Address: " + myStore.Address;
            }
        }

        // POST /post
        //Needed the TestPolicy for Cors when running localhost tests
        [EnableCors("TestPolicy")]
        [HttpPost("post")]
        public Boolean Post([FromBody] Store value)
        {
            //Will return true if successfully added the store provided or false if an error occurred
            try
            {
                return MyService.AddStore(value);
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        //PUT and DELETE were not implemented as they were not fit for our program

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
