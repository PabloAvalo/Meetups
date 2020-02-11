using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meetup.Api.Services;
using Meetup.Dto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Meetup.Api.ClimaHelper;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepo;



        private readonly IMapper _mapper;

        public EventoController(IEventoRepository repository, IMapper mapper)
        {
            _eventoRepo = repository;

            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEventos()
        {

            var eventos = _eventoRepo.GetEventos();

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));

        }

        [HttpGet("organizador/{organizadorId}")]
        public IActionResult GetEventosByEvento(int organizadorId)
        {

            var eventos = _eventoRepo.GetEventosByOrganizerId(organizadorId);

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));

        }

        [HttpGet("usuario/{userId}")]
        public IActionResult GetEventosByUser(int userId)
        {

            var eventos = _eventoRepo.GetEventosByUserId(userId);

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));

        }



        [HttpGet("{id}")]

        public IActionResult GetEvento(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!_eventoRepo.Exists(id))
            {
                return NotFound();
            }

            var evento = _eventoRepo.GetEventoById(id);



            return Ok(_mapper.Map<EventoDto>(evento));

        }

        [HttpPost]
        public IActionResult PostEvento(EventoNuevoDto evento)
        {

            var entity = _mapper.Map<Entities.Evento>(evento);

            _eventoRepo.AddEvento(entity);

            _eventoRepo.Save();

            EventoDto response = _mapper.Map<EventoDto>(entity);

            return CreatedAtAction("GetEvento",
                new { Id = entity.Id, response }
                );

        }

        [HttpGet("{eventoId}/cantidadDeBirras")]
        public IActionResult GetCantidadDeBirras(int eventoId)
        {

            var evento = _eventoRepo.GetEventoById(eventoId);

            if (evento == null) {

                return NotFound();
            
            }

            double? temp = ClimaHelper.ClimaHelper.GetTemperaturaDelEvento(evento.Ciudad, evento.Fecha)?.Result;

            if (temp == double.MinValue) {

               return NotFound("No se encontraron datos del clima para el evento");

            }

            int packsBirra = ProvicionesHelper.CantidadDeBirras(evento.Inscriptos.Count, temp.Value);

            return Ok(new
            {
                EventoId = eventoId,
                Cantidad = packsBirra,
                Mensaje = $"Necesitamos comprar {packsBirra} packs de Birra"

            });

        }

        [HttpDelete]

        public IActionResult Delete(int eventoId)
        {

            if (!_eventoRepo.Exists(eventoId))
            {
                return NotFound();
            }

            _eventoRepo.Remove(eventoId);

            _eventoRepo.Save();

            return Ok(new { Mensaje = $"Se elimino el evento con id : {eventoId} " });

        }

        [HttpPut]

        public IActionResult Put(EventoPutDto eventoDto)
        {

            if (!_eventoRepo.Exists(eventoDto.Id))
            { 
                return BadRequest();
            }


            var eventoModificado = _mapper.Map<Entities.Evento>(eventoDto);
            eventoModificado.FechaActualizacion = DateTime.Now;

            _eventoRepo.UpdateEvento(eventoModificado);
            
            _eventoRepo.Save();

            return Ok();

        }

        [HttpGet("{id}/Clima")]
        public async Task<IActionResult> GetClima(int eventoId)
        {

            if (!_eventoRepo.Exists(eventoId))
            {
                return NotFound();
            }

            var evento = _eventoRepo.GetEventoById(eventoId);
            ClimaDto dto = await ClimaHelper.ClimaHelper.GetClimaPorFecha(evento.Ciudad, evento.Fecha);

            if (dto == null)
            {
                return NotFound($"No se encontro el clima para la fecha {evento.Fecha}");
            }

            return Ok(dto);

        }


    }
}