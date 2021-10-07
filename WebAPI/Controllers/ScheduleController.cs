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

        [HttpPost]
        [Route("Automate Entry Time")]
        public IActionResult AutomateEntry(int id)
        {
            var autoSchedule = new Schedule();

            autoSchedule.CollaboratorId = id;
            autoSchedule.EntryTime = DateTime.Now;

            return Execute(() => _baseScheduleService.Add<ScheduleValidator>(autoSchedule).Id);

        }

        [HttpPost]
        [Route("Automate Lunch Time")]
        public IActionResult AutomateLunchTime(int id)
        {
            var autoSchedule = new Schedule();

            autoSchedule.CollaboratorId = id;
            autoSchedule.LunchTime = DateTime.Now;

            return Execute(() => _baseScheduleService.Add<ScheduleValidator>(autoSchedule).Id);

        }

        [HttpPost]
        [Route("Automate Return Lunch Time")]
        public IActionResult AutomateReturn(int id)
        {
            var autoSchedule = new Schedule();

            autoSchedule.CollaboratorId = id;
            autoSchedule.LunchReturnTime = DateTime.Now;

            return Execute(() => _baseScheduleService.Add<ScheduleValidator>(autoSchedule).Id);

        }

        [HttpPost]
        [Route("Automate Departure")]
        public IActionResult AutomateDeparture(int id)
        {
            var autoSchedule = new Schedule();

            autoSchedule.CollaboratorId = id;
            autoSchedule.DepartureTime = DateTime.Now;

            return Execute(() => _baseScheduleService.Add<ScheduleValidator>(autoSchedule).Id);

        }
        [HttpGet]
        [Route("CollaboratorSchedulesByToday/{id}")]

        public IActionResult CollaboratorSchedulesByUserByToday(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _Scheduleservice.GetSchedulesByUserByToday(id));

        }
        [HttpGet]
        [Route("CollaboratorSchedules")]
        public IActionResult GetSchedulesByCollaboratorId(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _Scheduleservice.GetAllByCollaboratorId(id));
        }
        [HttpGet]
        [Route("CheckSchedules")]
        public IActionResult BeatTime( int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _Scheduleservice.BeatTime(id));
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
