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
    public class ScheduleController : ControllerBase
    {
        private IBaseService<Schedule> _baseScheduleService;
        private IScheduleService _Scheduleservice;


        public ScheduleController(IBaseService<Schedule> baseScheduleService
            , IScheduleService ScheduleAplicattionService)
        {
            _baseScheduleService = baseScheduleService;
            _Scheduleservice = ScheduleAplicattionService;
        }



        [HttpPut]
        public IActionResult Update([FromBody] Schedule schedule)
        {
            if (schedule == null)
                return NotFound();

            return Execute(() => _baseScheduleService.Update<ScheduleValidator>(schedule));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseScheduleService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Schedule schedule)
        {
            if (schedule == null)
                return NotFound();

            return Execute(() => _baseScheduleService.Add<ScheduleValidator>(schedule).Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _Scheduleservice.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseScheduleService.GetById(id));
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
