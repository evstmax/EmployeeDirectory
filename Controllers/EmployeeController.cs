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
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;


        public EmployeeController(IUnitOfWork unitOfWork, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetAll();
                var results = _mapper.Map<IList<EmployeeDTO>>(employees);
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something Went Wrong in the {nameof(GetEmployee)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.Get(q => q.Id == id, new List<string> { "Position", "Department"});
                var result = _mapper.Map<EmployeeDTO>(employee);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something Went Wrong in the {nameof(GetEmployee)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }




    }
}
