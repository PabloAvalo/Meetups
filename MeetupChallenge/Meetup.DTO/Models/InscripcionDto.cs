using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class InscripcionDto
    {
      
        [Required(ErrorMessage ="Inscripcion debe tener un id de Evento")]
        public int EventoId { get; set; }

        [Required(ErrorMessage ="Inscripcion debe tener id usuario")]
        public int UsuarioId { get; set; }
        public bool CheckIn { get; set; }

  
    }
}
