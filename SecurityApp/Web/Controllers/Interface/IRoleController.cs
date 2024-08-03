using Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleController
    {
        Task<ActionResult<RoleDto>> GetById(int id);
        Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity);
        Task<IActionResult> Update(int id, [FromBody] RoleDto entity);
        Task<IActionResult> Delete(int id);
    }
}
