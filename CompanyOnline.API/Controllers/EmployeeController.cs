using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyOnline.API.Models;
using CompanyOnline.API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using System.Text;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace CompanyOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IDataRepository<Employee, long> _iRepo;
        protected readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IDataRepository<Employee, long> repo, ILogger<EmployeeController> logger = null)
        {
            _iRepo = repo;
            if (null != logger)
            {
                _logger = logger;
            }
        }
        
        //public EmployeeController(ILogger<EmployeeController> logger = null)
        //{
        //    if (null != logger)
        //    {
        //        _logger = logger;
        //    }
        //}
        //GET: api/values
        [HttpGet]
        [ActionName("Employees")]
        public IActionResult Get()
        {
            _logger.LogError("NLog test");
            _logger.LogTrace("Trace Log");
            var employees = _iRepo.GetAll();
            if (employees != null)
            {
                return Ok(employees);
            }
            else
                return NotFound();
        }
        // GET api/values/5  
        [HttpGet("{id}")]
        [ActionName("Employees")]
        public IActionResult Get(int id)
        {
            var employee = _iRepo.Get(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
                return NotFound();
        }

        // POST api/values
        [HttpPost]
        [ActionName("Employee")]
        public void Post([FromBody]Employee employee)
        {
            _iRepo.Add(employee);
        }

        // POST api/values  
        [HttpPut]
        [ActionName("Employee")]
        public void Put([FromBody]Employee employee)
        {
            _iRepo.Update(employee.Id, employee);
        }

        //DELETE api/values/5  
        [HttpDelete("{id}")]
        [ActionName("Employee")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}