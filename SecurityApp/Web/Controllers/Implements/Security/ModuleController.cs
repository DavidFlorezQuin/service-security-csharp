using Business.Security.Implementation;
using Business.Security.Interfaces;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements.Security
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase
    {

        private readonly IModuleBusiness _modulesBusiness;

        public ModuleController(IModuleBusiness ModuleBusiness)
        {
            _modulesBusiness = ModuleBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuloDto>> GetById(int id)
        {
            var result = await _modulesBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ModuloDto>> Save([FromBody] ModuloDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _modulesBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModuloDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _modulesBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _modulesBusiness.Delete(id);
            return NoContent();
        }
    }
}
