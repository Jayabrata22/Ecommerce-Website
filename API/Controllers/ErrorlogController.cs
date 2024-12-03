using API.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorlogController : ControllerBase
    {
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }
        [HttpGet("badrequest")]
        public IActionResult GetBadrequest()
        {
            return BadRequest("Request is not completed");
        }
        [HttpGet("notfound")]
        public IActionResult GetNotfound()
        {
            return NotFound();
        }
        [HttpGet("internalerror")]
        public IActionResult getinternalError()
        {
            throw new Exception("This is test Exception");
        }
        [HttpPost("validationerror")]
        public IActionResult GetValidationError( ProductDTO product)
        {
           return Ok();
        }
    }
}
