using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class EventoNuevoDto
    {
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [MaxLength(60)]
        public string Descripcion { get; set; }


        [Required]
        public int TopicoId { get; set; }
   

        [Required]
        [MaxLength(30)]
        public string Ciudad { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int OrganizadorId { get; set; }
    }
}
