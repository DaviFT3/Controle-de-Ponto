using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IBaseService<Company> _baseCompanyService;
        private ICompanyService _companyservice;
        

        public CompanyController(IBaseService<Company> baseCompanyService
            , ICompanyService CompanyAplicattionService)
        {
            _baseCompanyService = baseCompanyService;
            _companyservice = CompanyAplicattionService;
        }



        [HttpPut]
        public IActionResult Update([FromBody] Company company)
        {
            if (company == null)
                return NotFound();

            return Execute(() => _baseCompanyService.Update<CompanyValidator>(company));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseCompanyService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Company company)
        {
            if (company == null)
                return NotFound();

            return Execute(() => _baseCompanyService.Add<CompanyValidator>(company).Id);
        }
       

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseCompanyService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseCompanyService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
