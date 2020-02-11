using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetup.Dto.Models
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage ="Debe Ingresar Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage ="Debe Ingresar Contraseña")]
        public string Contraseña { get; set; }
    }
}
