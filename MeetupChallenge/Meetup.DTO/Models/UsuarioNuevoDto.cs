using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class UsuarioNuevoDto
    {
    
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }

        public bool IsAdmin { get; set; }
    }
}
