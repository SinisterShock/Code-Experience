using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewPartsUsers.Models.Entities;
using NewPartsUsers.Services;

namespace NewPartsUsers.Controllers
{
    [EnableCors]
    [Route("api/user")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserAPIController(IUserRepository userRepository)
        {
            _userRepo= userRepository;
        }

        /// <summary>
        /// Sends a list of all user records using GET and the read all function
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_userRepo.ReadAll());
        }

        /// <summary>
        /// returns one record using GET and the read function when given an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("one/{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepo.Read(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Creates a user in the database from the POST request and using the create function 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Post([FromForm] User user)
        {
            _userRepo.Create(user);
            return CreatedAtAction("Get", new { id = user.Id }, user);

        }

        /// <summary>
        /// Updates an existing record using PUT and the update function
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Put([FromForm] User user)
        {
            _userRepo.Update(user.Id, user);
            return NoContent();
        }

        /// <summary>
        /// Deletes a record from the database using DELETE and the delete function
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _userRepo.Delete(id);
            return NoContent();
        }
    }
}
