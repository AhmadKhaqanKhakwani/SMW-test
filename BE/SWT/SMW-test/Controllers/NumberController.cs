using Microsoft.AspNetCore.Mvc;
using SMW_test.Services.Implementation;
using SMW_test.Services.Interface;
using SMW_test.Utilities.DataStructure;

namespace SMW_test.Controllers
{
    [ApiController]
    [Route("api/numbers")]
    public class NumbersController : ControllerBase
    {
        private readonly INumberService _numberService;

        public NumbersController(INumberService numberService)
        {
            _numberService = numberService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNumber([FromBody] int number)
        {
            await _numberService.AddNumberAsync(number);
            return Ok($"Number {number} added successfully.");
        }

        [HttpGet("max")]
        public async Task<IActionResult> GetMaxNumber()
        {
            var max = await _numberService.GetMaxAsync();
            if (max.HasValue)
                return Ok(max.Value);
            else
                return NotFound("No numbers stored.");
        }

        [HttpGet("min")]
        public async Task<IActionResult> GetMinNumber()
        {
            var min = await _numberService.GetMinAsync();
            if (min.HasValue)
                return Ok(min.Value);
            else
                return NotFound("No numbers stored.");
        }

        [HttpPost("set-datastructure")]
        public IActionResult SetActiveDataStructure([FromBody] DataStructureModel model)
        {
            _numberService.SetActiveDataStructure(model.DataStructure);
            return Ok($"Active data structure set to {model.DataStructure}.");
        }
    }
}
