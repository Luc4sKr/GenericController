using GenericController.Appliction.API.Models;
using GenericController.Appliction.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericController.Appliction.API.Controllers
{
    [ApiController]
    public class GenericBaseController<T> : ControllerBase where T : BaseModel
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
                return BadRequest(id);
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
                return BadRequest(entity);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(Guid id, [FromBody] T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            try
            {
                await this._baseService.Update(entity);
                return Ok(entity);
            }
            catch
            {
                return BadRequest(entity);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                T entity = this._baseService.GetById(id);

                if (entity == null)
                {
                    return NotFound(id);
                }

                this._baseService.Delete(entity);

                return Delete(id);
            }
            catch
            {
                return BadRequest(id);
            }
        }
    }
}
