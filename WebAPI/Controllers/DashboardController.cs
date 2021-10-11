using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    public class DashboardController : ControllerBase
    {
        private IBaseService<Dashboard> _baseDashboardService;
        private IDashboardService _dashboardService;
        

        public DashboardController(IBaseService<Dashboard> baseDashboardService
            , IDashboardService dashboardService)
        {
            _baseDashboardService = baseDashboardService;
            _dashboardService =  dashboardService;
           
        }
       [HttpPut]
       [Route("UpdateDatesDashboard")]
       public IActionResult UpdateDashboard(int idUser)
       {
            if (idUser == 0)
            return NotFound();
            return Execute(() => _dashboardService.UpdateDashboard(idUser));
        }


        [HttpPut]
        public IActionResult Update([FromBody] Dashboard dashboard)
        {
            if (dashboard == null)
                return NotFound();

            return Execute(() => _baseDashboardService.Update<DashboardValidator>(dashboard));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseDashboardService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Dashboard dashboard)
        {
            if (dashboard == null)
                return NotFound();

            return Execute(() => _baseDashboardService.Add<DashboardValidator>(dashboard).Id);
        }
        


        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _dashboardService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseDashboardService.GetById(id));
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
