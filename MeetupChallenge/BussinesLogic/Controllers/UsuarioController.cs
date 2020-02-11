using BussinesLogic.APIManager;
using BussinesLogic.Controllers;
using Meetup.Dto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BussinesLogic.Controllers
{
    public static class UsuarioController

    {
        private const string baseUrl = "https://localhost:44372/api";
        public static async Task HacerCheckIn(int eventoId)
        {
            InscripcionDto dto = new InscripcionDto { EventoId = eventoId, CheckIn = true };
            using (var response = await APIHelper.ApiClient.PutAsJsonAsync($"/inscripcion/{baseUrl}/{eventoId}", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        //public void EliminarTopico()
        //{
        //    throw new NotImplementedException();
        //}

        //public void FavearTopico()
        //{
        //    throw new NotImplementedException();
        //}

        public static async Task RegistrarInscripcion(int usuarioId, int eventoId)
        {
            InscripcionNuevaDto dto = new InscripcionNuevaDto() { UsuarioId = usuarioId, EventoId = eventoId };
            using (var response = await APIHelper.ApiClient.PostAsJsonAsync("/inscripcion", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public static async Task<UsuarioDto> Login(string usuario, string contraseña)
        {
            UsuarioLoginDto dto = new UsuarioLoginDto() { Usuario = usuario, Contraseña = contraseña };
            UsuarioDto loggedInUsuario = new UsuarioDto();
            
            using (var response = await APIHelper.ApiClient.PostAsJsonAsync("/Usuarios", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string usu = await response.Content.ReadAsStringAsync();

                JsonConvert.PopulateObject(usu, loggedInUsuario);


            }

            return loggedInUsuario;
        }


        public static async Task SignUp(string correo, string contraseña, bool isAdmin, string nombre)
        {

            UsuarioNuevoDto dto = new UsuarioNuevoDto()
            {
                Correo = correo,
                Contraseña = contraseña,
                IsAdmin = isAdmin,
                Nombre = nombre
            };

            using (var response = await APIHelper.ApiClient.PostAsJsonAsync($"/Usuarios", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
