using AutoMapper;
using Meetup.Api.Context;
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
    public class TopicosController : ControllerBase
    {

        private MeetUpContext _context;
        private readonly IMapper _mapper;
        public TopicosController(MeetUpContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTopicos() {

            var topicos = _context.Topicos.ToList();

            return Ok(_mapper.Map<IEnumerable<TopicoDto>>(topicos));
            
        }

    }
}
