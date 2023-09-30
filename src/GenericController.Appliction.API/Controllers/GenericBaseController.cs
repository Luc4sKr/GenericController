using Microsoft.AspNetCore.Mvc;

namespace GenericController.Appliction.API.Controllers
{
    [ApiController]
    public class GenericBaseController<T> : ControllerBase where T : class
    {

    }
}
