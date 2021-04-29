using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Extensions;
using SynetecAssessmentApi.Services;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusPoolController : ControllerBase
    {
        private readonly IBonusPoolService _bonusPoolService;
        private readonly IMapper _mapper;

        public BonusPoolController(IBonusPoolService bonusPoolService, IMapper mapper)
        {
            _bonusPoolService = bonusPoolService;
            _mapper = mapper;
        }

        // GET: api/<BonusPoolController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok((await _bonusPoolService.GetEmployeesAsync()).MapEmployeesToEmployeeDto(_mapper));
        }

        // POST api/<BonusPoolController>
        [HttpPost]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var calculatorResult = await _bonusPoolService.CalculateAsync(request.TotalBonusPoolAmount, request.SelectedEmployeeId);

            if (calculatorResult == null )
            {
                return BadRequest("The Employee does not exists.");
            }

            return Ok(calculatorResult);
        }
    }
}
