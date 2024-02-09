using API_FloorAssign.IRepo;
using API_FloorAssign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FloorAssign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo _repo;

        public UserController(IUserRepo repo)
        {

            _repo = repo;
        }
        [HttpGet]
        [Route("GetUsers/{id}")]
        public IActionResult GetUsers(int id)
        {
            var data = _repo.GetUsers(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);

            }

        }

        [HttpGet]
        [Route("GetProfileUser/{email}")]
        public IActionResult GetProfileUser(string email)
        {

            var data = _repo.GetProfileUser(email);
            if(data.Count ==0)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(UserRegistration user)
        {
            bool value;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                value = _repo.AddUser(user);
                if(value)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
                
            }
        }
        [HttpPost]
        [Route("AddUserDetails")]
        public IActionResult AddUserDetails(UserDetails user)
        {
            bool value;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                value = _repo.AddUserDetails(user);
                if (value)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
        }

        [HttpGet]
        [Route("GetUserRegId/{email}")]

        public IActionResult GetUserRegId(string email)
        {
           var UserId=  _repo.GetUserId(email);
            return Ok(UserId);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdateUserDetails(UserDetails user, int id)
        {
            bool res = _repo.UpdateUserDetails(user, id);
            if(res)
            {
                return Ok("Updated Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _repo.DeleteUser(id);
            return Ok("Deleted");
        }
    }
}
