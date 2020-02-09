using Meetup.Api.Context;
using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly MeetUpContext _context;

        public UsuarioRepository(MeetUpContext context)
        {
            _context = context;
        }
        public void AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

    

        public Usuario ObtenerUsuario(string user, string contraseña)
        {
            return _context.Usuarios.Where(u => u.Correo == user && u.Contraseña == contraseña).SingleOrDefault();
        }

        public Usuario ObtenerUsuario(int usuarioId)
        {
            return _context.Usuarios.Find(usuarioId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
