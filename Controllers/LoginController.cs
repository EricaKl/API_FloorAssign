using API_FloorAssign.IRepo;
using API_FloorAssign.Repo;
using API_FloorAssign.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API_FloorAssign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginRepo _repo;
        public LoginController(ILoginRepo repo)
        {
            _repo = repo;


        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel loginobj)
        {

            bool obj = _repo.Login(loginobj);

            if (obj)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
