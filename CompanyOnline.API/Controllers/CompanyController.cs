using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompanyOnline.API.Models;
using CompanyOnline.API.Models.Repository;
using CompanyOnline.API.Models.DataManager;
using System.Web.Http;
using Microsoft.Extensions;
using Microsoft.Extensions.Logging;
using log4net;
using System.Reflection;
using CompanyOnline.API.Filters;

namespace CompanyOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class CompanyController : Controller
    {
        private IDataRepository<Company, long> _iRepo;
        private ILog _logger;
        public CompanyController(IDataRepository<Company, long> repo)
        {
            _iRepo = repo;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        //GET: api/values
        [HttpGet]
        [ActionName("Companies")]
        public IActionResult Get()
        {
            _logger.Info("INFO!: Invocking repository to get all companies.");

            var companies = _iRepo.GetAll();
            if (companies != null)
            {
                return Ok(companies);
            }
            else
                return NotFound();
        }

        // GET api/values/5  
        [HttpGet("{id}")]
        [ActionName("Companies")]
        public IActionResult Get(int id)
        {
            _logger.Info("INFO!: Invocking repository Get  company details .");
            var company = _iRepo.Get(id);
            if (company != null)
            {
                return Ok(company);
            }
            else
                return NotFound();
        }

        // POST api/values
        [HttpPost]
        [ActionName("Company")]
        public void Post([FromBody]Company company)
        {
            _logger.Info("INFO!: Invocking repository to upadte company.");
            _iRepo.Add(company);
        }

        // POST api/values  
        [HttpPut]
        [ActionName("Company")]
        public void Put([FromBody]Company company)
        {
            _iRepo.Update(company.Id, company);
        }

        //DELETE api/values/5  
        [HttpDelete("{id}")]
        [ActionName("Company")]
        public long Delete(int id)
        {
            _logger.Info("INFO!: Invocking repository to  delete company.");
            return _iRepo.Delete(id);
        }
    }
}