using GenericController.Appliction.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericController.Appliction.API.Controllers
{
    [ApiController]
    public class GenericBaseController<T> : ControllerBase where T : class
    {
        private readonly IBaseService<T> _baseService;

        public GenericBaseController(IBaseService<T> baseService)
        {
            this._baseService = baseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            try
            {
                List<T> entities = this._baseService.GetAll();

                if (entities.Count == 0)
                {
                    return NotFound();
                }

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(Guid id)
        {
            try
            {
                T entity = this._baseService.GetById(id);

                if (entity == null)
                {
                    return NotFound(id);
                }

                return Ok(entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody] T entity)
        {
            try
            {
                await this._baseService.Create(entity);
                return Ok(entity);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
