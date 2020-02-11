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
    public static class OrganizadorMeetup
    {

        private const string baseUrl = "https://localhost:44372/api/evento";
        public static async Task<EventoDto> CrearMeetUpAsync(string nombre, string ciudad, string descripcion, DateTime fecha, int organizadorId, int topicoId)
        {
            EventoNuevoDto evento = new EventoNuevoDto()
            {

                Nombre = nombre,
                Ciudad = ciudad,
                Descripcion = descripcion,
                Fecha = fecha,
                OrganizadorId = organizadorId,
                TopicoId = topicoId
            };
            EventoDto eventoNuevo = new EventoDto();

            using (HttpResponseMessage response = await APIHelper.ApiClient.PostAsJsonAsync(baseUrl, evento))
            {

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                string content = await response.Content.ReadAsStringAsync();

                JsonConvert.PopulateObject(content, eventoNuevo);

            }

            return eventoNuevo;

        }
              
        public static async Task EliminarMeetUp(int eventoId)
        {
            using (HttpResponseMessage response = await APIHelper.ApiClient.DeleteAsync(baseUrl + $"/{eventoId}"))
            {

                if (!response.IsSuccessStatusCode)
                {

                    throw new Exception(response.ReasonPhrase);

                }

            }

        }

        //public void EnviarInvitaciones()
        //{
        //    throw new NotImplementedException();
        //}

        public static async Task<int> ObtenerCantidadDeBirras(int eventoId, int temperatura)
        {

            int cantidadBirraas = 0;

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(baseUrl + $"/{eventoId}/{temperatura}"))
            {

                if (!response.IsSuccessStatusCode)
                {

                    return -1;

                }

                var birras = response.Content.ReadAsStringAsync();

                cantidadBirraas = 1;


            }

            return cantidadBirraas;
        }

        //public void UpdateMeetUp()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
