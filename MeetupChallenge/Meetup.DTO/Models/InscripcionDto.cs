using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.Dto.Models
{
    public class InscripcionDto
    {
      
        public EventoDto Evento { get; set; }
        public UsuarioDto Usuario { get; set; }
        public bool CheckIn { get; set; }
    }
}
