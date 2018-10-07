using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebApp_TEST.Models
{
    public class RoleClient
    {
        //WebAPI URL
        private string API_URL = ConfigurationManager.AppSettings["URI"].ToString();


        //OBTENER TODOS LOS REGISTROS

        public IEnumerable<Role> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Roles").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Role>>().Result;

                }
                return null;
            }

            catch
            {
                return null;
            }

        }

        //ENCONTRAR UN SOLO VALOR

        public Role find(int? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Roles/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Role>().Result;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e);
                return null;
            }

        }

        //CREAR ELEMENTO ROLE

        public bool Create(Role Role)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Roles", Role).Result;
                var respuesta = response.IsSuccessStatusCode;

                return respuesta;
            }
            catch
            {
                return false;
            }
        }

        //EDITAR ELEMENTO ROLE

        public bool Edit(Role Role)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Roles/" + Role.id, Role).Result;
                var respuesta = response.IsSuccessStatusCode;

                return respuesta;
            }
            catch
            {
                return false;
            }
        }

        //BORRAR ELEMENTO ROLE

        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Roles/" + id).Result;
                var respuesta = response.IsSuccessStatusCode;

                return respuesta;
            }
            catch
            {
                return false;
            }
        }
    }
}