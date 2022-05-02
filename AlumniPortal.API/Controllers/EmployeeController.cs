using AlumniPortal.Domain.Entities;
using AlumniPortal.Domain.Interfaces.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet("GetEmployees")]
        public Task<IEnumerable<AlumniPersonalDetails>> GetEmployees([FromQuery] int count)
        {
            return  _employee.GetEmployees(count);
        }
    }
}
