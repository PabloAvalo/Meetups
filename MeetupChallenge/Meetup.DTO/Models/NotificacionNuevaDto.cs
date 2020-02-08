using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class NotificacionNuevaDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Mensaje { get; set; }

        public string Link { get; set; }
    }
}
