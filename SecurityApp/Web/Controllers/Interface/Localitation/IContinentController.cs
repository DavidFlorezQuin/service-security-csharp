using Entity.Model.Dto.Localitation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface.Localitation
{
    public interface IContinentController
    {
        Task<ActionResult<ContinentDto>> GetById(int id);
        Task<ActionResult<ContinentDto>> Save([FromBody] ContinentDto entity);
        Task<IActionResult> Update(int id, [FromBody] ContinentDto entity);
        Task<IActionResult> Delete(int id);
    }
}
