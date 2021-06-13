using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeDirectory.IRepository;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeDirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PositionController> _logger;
        private readonly IMapper _mapper;


        public PositionController(IUnitOfWork unitOfWork, ILogger<PositionController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPosition()
        {
            try
            {
                var positions = await _unitOfWork.Positions.GetAll();
                var results = _mapper.Map<IList<PositionDTO>>(positions);
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something Went Wrong in the {nameof(GetPosition)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPosition(int id)
        {
            try
            {
                var position = await _unitOfWork.Positions.Get(q => q.Id == id, new List<string> {"Employees"});
                var result = _mapper.Map<PositionDTO>(position);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something Went Wrong in the {nameof(GetPosition)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }

        }
    }
}
