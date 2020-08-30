using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Waldo.Entity;
using Waldo.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Waldo.Controllers
{
    //Route sets so that the url matches https://waldofind.azurewebsites.net/user
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //Established our UserService which communicates with our SQL database
        UserService MyService = new UserService();

        // GET
        //Needed the TestPolicy for Cors when running localhost tests
        [EnableCors("TestPolicy")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //Returns a list of all the users we have info on in the database
            return MyService.GetUsers();
        }

        // GET /get/5
        //Needed the TestPolicy for Cors when running localhost tests
        [EnableCors("TestPolicy")]
        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            //Gets the user from our database with the store id entered
            User myUser = MyService.GetUser(id);
            //Displays a no user message if it does not exist
            if (myUser == null)
            {
                return "No User with that Id";
            }
            //Displays the user's username and password if it exists
            else
            {
                return "User: " + myUser.Username + " Pass: " + myUser.Password;
            }
        }

        // POST /post
        //Needed the TestPolicy for Cors when running localhost tests
        [EnableCors("TestPolicy")]
        [HttpPost("post")]
        public Boolean Post([FromBody] User value)
        {
            //Will return true if successfully added the store provided or false if an error occurred
            try
            {
                return MyService.AddUser(value);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //PUT and DELETE were not implemented as they were not fit for our program

        // PUT api/values/5
        [HttpPut("put/{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
