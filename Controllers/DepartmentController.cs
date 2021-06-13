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
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IMapper _mapper;


        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            try
            {
                var departments = await _unitOfWork.Departments.GetAll();
                var results = _mapper.Map<IList<DepartmentDTO>>(departments);
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something Went Wrong in the {nameof(GetDepartment)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }




    }
}
