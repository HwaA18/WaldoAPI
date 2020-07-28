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
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UserService MyService = new UserService();

        // GET: api/values
        [EnableCors("TestPolicy")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //UserService MyService = new UserService();
            return MyService.GetUsers();
        }

        // GET api/values/5
        [EnableCors("TestPolicy")]
        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            //UserService MyService = new UserService();
            User myUser = MyService.GetUser(id);
            if (myUser == null)
            {
                return "No User with that Id";
            }
            else
            {
                return "User: " + myUser.Username + " Pass: " + myUser.Password;
            }
        }

        // POST api/values
        [EnableCors("TestPolicy")]
        [HttpPost("post")]
        public Boolean Post([FromBody] User value)
        {
            //if (value == null)
            //{
            //    return false;
            //} else
            //{
            //    return true;
            //}
            return MyService.AddUser(value);
            //if (MyService.GetUser(2).Username == "ctang")
            //{
            //    return true;
            //} else
            //{
            //    return false;
            //}

        }

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
