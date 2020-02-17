using BussinesLogic.APIManager;
using BussinesLogic.Controllers;
using IdentityModel.Client;
using Meetup.BussinesLogic.APIManager;
using Meetup.Dto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BussinesLogic.Controllers
{
    public class UsuarioController : IUsuarioController

    {
        private const string Topico = "Topic"; //deberia ser un enum

        private const string baseUrl = "https://localhost:44372/api";
        public async Task HacerCheckIn(int inscripcionId)
        {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);


            using (var response = await apiClient.PostAsync(baseUrl + $"/inscripcion/{inscripcionId}/CheckIn", null))
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

        //eliminar Inscripcion 

        public async Task AddTopicoFavorito(int usuarioId, int topicoId)
        {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            ConfiguracionNuevaDto configuracion = new ConfiguracionNuevaDto
            {
                Key = "Topic",
                UsuarioId = usuarioId,
                Value = topicoId.ToString()
            };

            using (var response = await apiClient.PostAsJsonAsync("/Usuarios/preferencias", configuracion))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }



        }

        public async Task RegistrarInscripcion(int usuarioId, int eventoId)
        {
            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            InscripcionNuevaDto dto = new InscripcionNuevaDto() { UsuarioId = usuarioId, EventoId = eventoId };
            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync("/inscripcion", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task<UsuarioDto> Login(string usuario, string contraseña)
        {
            UsuarioLoginDto dto = new UsuarioLoginDto() { Usuario = usuario, Contraseña = contraseña };
            UsuarioDto loggedInUsuario = new UsuarioDto();

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);


            using (var response = await apiClient.PostAsJsonAsync("/Usuarios", dto))
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

        public async Task SignUp(string correo, string contraseña, bool isAdmin, string nombre)
        {

            UsuarioNuevoDto dto = new UsuarioNuevoDto()
            {
                Correo = correo,
                Contraseña = contraseña,
                IsAdmin = isAdmin,
                Nombre = nombre
            };

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);


            using (var response = await apiClient.PostAsJsonAsync($"/Usuarios", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //obtenerNotificaciones (int userId); 



    }
}
