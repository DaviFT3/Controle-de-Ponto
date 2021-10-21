using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Validators;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DayOffController : ControllerBase
    {
        private IBaseService<DayOff> _baseDayOffService;
        private IDayOffService _dayOffService;


        public DayOffController(IBaseService<DayOff> baseDayOffService
            , IDayOffService dayOffService)
        {
            _baseDayOffService = baseDayOffService;
            _dayOffService = dayOffService;

        }



        [HttpGet]
        [Route("byCompanyId")]
        public IActionResult GetHappyByCompanyIdAndYearAndMonth([FromQuery] int idCompany, [FromQuery] int year, [FromQuery] int month)
        {
            return Execute(() => _dayOffService.GetDayOffByCompanyId(idCompany, year, month));
        }
        [HttpGet]
        [Route("GetAllByUserId")]
        public IActionResult GetAllByUserId()
        {
            return Execute(() => _dayOffService.GetAllByCollaboratorId());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] DayOffViewModel happyFriday)
        {
            if (happyFriday == null)
                return NotFound();

            return Execute(() => _dayOffService.Create(happyFriday));
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
