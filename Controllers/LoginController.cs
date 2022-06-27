using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using EcommerceApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        EcommerceDBContext db;
        IJWTMangerRepository iJWTMangerRepository;

        public LoginController(EcommerceDBContext _db, IJWTMangerRepository _iJWTMangerRepository)
        {
            db = _db;
            iJWTMangerRepository = _iJWTMangerRepository;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var token = iJWTMangerRepository.Authenicate(loginViewModel, false);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = registerViewModel.UserName;
            login.Password = registerViewModel.Password;
            if (iJWTMangerRepository.Authenicate(login, true).IsUserExits)
            {
                return Ok("User already exists");
            }
            if (iJWTMangerRepository.Authenicate(login, true) == null)
            {
                return Unauthorized();
            }
            return base.Ok(iJWTMangerRepository.Authenicate(login, true));
        }
    }
}
