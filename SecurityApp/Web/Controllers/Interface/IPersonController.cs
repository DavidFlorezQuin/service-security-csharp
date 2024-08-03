using Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IPersonController
    {
        Task<ActionResult<PersonDto>> GetById(int id);
        Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity);
        Task<IActionResult> Update(int id, [FromBody] PersonDto entity);
        Task<IActionResult> Delete(int id);
    }
}
