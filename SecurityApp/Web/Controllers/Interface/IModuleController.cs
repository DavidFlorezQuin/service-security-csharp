using Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IModuleController
    {
        Task<ActionResult<ModuloDto>> GetById(int id);
        Task<ActionResult<ModuloDto>> Save([FromBody] ModuloDto entity);
        Task<IActionResult> Update(int id, [FromBody] ModuloDto entity);
        Task<IActionResult> Delete(int id);
    }
}
