using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meetup.Api.Services;
using Meetup.Dto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _repository;

        private readonly IMapper _mapper;

        public EventoController(IEventoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEventos() {

            var eventos = _repository.GetEventos();

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));
            
        }

      



    }
}