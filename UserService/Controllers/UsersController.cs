using CommonCoreService.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Models;
using UserMicroService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserMicroService.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userService.GetUsers().ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (_userService.UserNameExists(user.UserName))
            {
                throw new BizException("用户名已存在");
            }
            _userService.Create(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            try
            {
                _userService.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!ExistsUser(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.Delete(user);
            return user;
        }
        private bool ExistsUser(int id)
        {
            return _userService.UserExists(id);
        }
    }
}
