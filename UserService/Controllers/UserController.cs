using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Database;
using UserService.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly DatabaseContext databaseContext;

        public UserController()
        {
            databaseContext = new DatabaseContext();
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return databaseContext.Users.ToList();
        }

        // GET api/User/id
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return databaseContext.Users.Find(id);
        }

        // POST api/User
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        { 
            try
            {
                databaseContext.Add(model);
                databaseContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                throw;
            }            
        }
    }
}
