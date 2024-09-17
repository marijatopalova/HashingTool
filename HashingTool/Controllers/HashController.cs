using HashingTool.Models;
using HashingTool.Services;
using Microsoft.AspNetCore.Mvc;

namespace HashingTool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HashController(IHashingService hashingService) : ControllerBase
    {
        [HttpPost("create-hash")]
        public IActionResult CreateHash([FromBody] HashRequest request)
        {
            if(string.IsNullOrEmpty(request.Base64Data))
            {
                return BadRequest("No data was provided.");
            }

            var hash = hashingService.ComputeHash(request.Base64Data);
            return Ok(new HashResponse { Hash = hash });
        }

        [HttpPost("validate-hash")]
        public IActionResult ValidateHash([FromBody] ValidateHashRequest request)
        {
            if(string.IsNullOrEmpty(request.Base64Data) || string.IsNullOrEmpty(request.ExpectedHash))
            {
                return BadRequest("Data or hash is missing.");
            }

            var isValid = hashingService.ValidateHash(request.Base64Data, request.ExpectedHash);
            return Ok(new ValidationHashResponse { IsValid = isValid });
        }
    }
}
