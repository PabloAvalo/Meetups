using AutoMapper;
using Meetup.Api.Services;
using Meetup.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioController(IUsuarioRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            usuarioRepository = repo;
        }

        [HttpPost]
        [Route("SingUp")]
        public IActionResult SingUp(UsuarioNuevoDto usuarioNuevo)
        {

            if (usuarioRepository.Exists(usuarioNuevo.Nombre))
            {
                return BadRequest("Usuario ya registrado");
            }

            


            var entity = mapper.Map<Entities.Usuario>(usuarioNuevo);

            usuarioRepository.AddUsuario(entity);

            usuarioRepository.Save();

            var response = mapper.Map<UsuarioDto>(entity);

            return Ok(new { Id = response.Id, response });



        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UsuarioLoginDto usuario)
        {

            if (!usuarioRepository.Exists(usuario.Usuario, usuario.Contraseña))
            {

                return BadRequest("Usuario inexistente");
            }

            var usu = usuarioRepository.ObtenerUsuario(usuario.Usuario, usuario.Contraseña);

            return Ok(mapper.Map<UsuarioDto>(usu));

        }



        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok(mapper.Map<IEnumerable<UsuarioDto>>(usuarioRepository.ObtenerUsuarios()));
        }

        [HttpPost]
        [Route("Preferencias")]
        public IActionResult AddTopicoDePreferencia(ConfiguracionNuevaDto configuracion) {

            var usuario = usuarioRepository.ObtenerUsuario(configuracion.UsuarioId);

            if (usuario == null)
            {
                return NotFound();
            }
                       
            usuario.Configuracion.Add(mapper.Map<Entities.Configuracion>(configuracion));

            usuarioRepository.Save();

            return Ok($"Se agrego la configuracion");
        
        }


    }
}
