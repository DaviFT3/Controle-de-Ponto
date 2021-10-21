using API.Configure;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private IBaseService<Collaborator> _baseCollaboratorService;
        private ICollaboratorService _collaboratorservice;
        private readonly ILogger<CollaboratorController> _logger;

        public CollaboratorController(IBaseService<Collaborator> baseCollaboratorService
            , ICollaboratorService CollaboratorAplicattionService, ILogger<CollaboratorController> logger)
        {
            _baseCollaboratorService = baseCollaboratorService;
            _collaboratorservice = CollaboratorAplicattionService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(Login login)
        {
            var authenticate = _collaboratorservice.GetAllAuthentication(login.email, login.password);

            // Verifica se o usuário existe
            if (authenticate == null)
            {
                _logger.LogError("Usuario não encontrado.");
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
            _logger.LogInformation("Usuario logado.");

            // Gera o Token
            var token = TokenService.GenerateToken(authenticate);

            // Oculta a senha
            authenticate.Password = "";

            // Retorna os dados
            return new
            {
                user = authenticate,
                token = token
            };
        }

        [HttpGet]
        [Route("authorized")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);


        [HttpPost]
        public IActionResult Create([FromBody] Collaborator collaborator)
        {
            if (collaborator == null)
                return NotFound();

            return Execute(() => _baseCollaboratorService.Add<CollaboratorValidator>(collaborator).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Collaborator collaborator)
        {
            if (collaborator == null)
                return NotFound();

            return Execute(() => _baseCollaboratorService.Update<CollaboratorValidator>(collaborator));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseCollaboratorService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _collaboratorservice.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _collaboratorservice.GetById(id));
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
