using AliGulmen.Week2.HomeWork.RestfulApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AccountController : ControllerBase
    {




        [HttpGet]
        [CustomPermission("admin")]
       


        public IActionResult IsLoggedIn(string username, string password)
        {
            var pass = "1234";

            var permissions = typeof(AccountController)
                .GetMethod("IsLoggedIn")
                .GetCustomAttributes(typeof(CustomPermissionAttribute), true)
                .Cast<CustomPermissionAttribute>()
                .Select(x => x.Permission).ToArray();

            if(permissions.Any(p => p == username) && password == pass)
            return Ok();
            return Unauthorized();
        }



    }
}
