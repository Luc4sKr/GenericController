using GenericController.Appliction.API.Models;
using GenericController.Appliction.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericController.Appliction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericBaseController<User>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base(userService)
        {
            this._userService = userService;
        }
    }
}
