using Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserRoleController
    {
        Task<ActionResult<UserRoleDto>> GetById(int id);
        Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserRoleDto entity);
        Task<IActionResult> Delete(int id);
    }
}
