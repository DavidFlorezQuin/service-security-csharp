using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface.Security
{
    public interface IRoleViewController
    {
        Task<ActionResult<RoleViewDto>> GetById(int id);
        Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto entity);
        Task<IActionResult> Update(int id, [FromBody] RoleViewDto entity);
        Task<IActionResult> Delete(int id);
    }
}
