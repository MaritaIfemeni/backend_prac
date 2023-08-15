using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapi.Business.src.Abstractions;
using Webapi.Domain.src.Shared;

namespace Webapi.Controller.src.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class CrudController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        private readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _baseService;

        public CrudController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            Console.WriteLine("again" + queryOptions.Search); // to see if the query options are passed
            return Ok(await _baseService.GetAll(queryOptions));
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<ActionResult<TReadDto>> GetOneById([FromRoute] Guid id)
        {
            return Ok(await _baseService.GetOneById(id));
        }

        [HttpPost]
        public virtual async Task<ActionResult<TReadDto>> CreateOne([FromBody] TCreateDto dto)
        {
            var createdObject = await _baseService.CreateOne(dto);
            return CreatedAtAction(nameof(CreateOne), createdObject);
        }

        [HttpPatch("{id:Guid}")]
        public virtual async Task<ActionResult<TReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] TUpdateDto update)
        {
            return Ok(await _baseService.UpdateOneById(id, update));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id)
        {
            //some other options:
            // return Ok(await _baseService.DeleteOneById(id));
            // NoContent()
            return StatusCode(204, await _baseService.DeleteOneById(id));
        }
    }
}