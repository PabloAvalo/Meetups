using Meetup.Api.Context;
using Meetup.Api.Entities;
using Microsoft.EntityFrameworkCore;
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

        public bool Exists(string correo)
        {
            return _context.Usuarios.Any(u => u.Correo == correo);
        }

        public bool Exists(string correo, string contraseña)
        {
            return _context.Usuarios.Any(u => u.Correo == correo && u.Contraseña == contraseña);
        }

        public Usuario ObtenerUsuario(string user, string contraseña)
        {
            var usu =  _context.Usuarios.Where(u => u.Correo == user && u.Contraseña == contraseña).Include( c => c.Configuracion).SingleOrDefault();
            return usu;
        }

        public Usuario ObtenerUsuario(int usuarioId)
        {
            return _context.Usuarios.Find(usuarioId);
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
