using API.Requesthelper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : ControllerBase
    {
        protected async Task<ActionResult> CreatePageResult<T>(IgenericRepository<T> repo,
           ISpecificRepository<T> spec, int PageIndex , int PageSize) where T : BaseEntity
        {
            var items = await repo.ListAsync(spec);
            var count = await repo.CountAsync(spec);
            var pagination = new Pagination<T>(PageIndex, PageSize, count,items);
            return Ok(pagination);
        }

    }
}
