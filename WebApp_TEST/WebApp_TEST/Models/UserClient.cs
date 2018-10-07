using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebApp_TEST.Models
{
    public class UserClient
    {
        //WebAPI URL
        private string API_URL = ConfigurationManager.AppSettings["URI"].ToString();


        //OBTENER TODOS LOS REGISTROS

        public IEnumerable<User> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Users").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<User>>().Result;

                }
                return null;
            }

            catch
            {
                return null;
            }

        }

        //ENCONTRAR UN SOLO VALOR

        public User find(int? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Users/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<User>().Result;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e);
                return null;
            }

        }

        //CREAR ELEMENTO USER

        public bool Create(User User)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Users", User).Result;
                var respuesta = response.IsSuccessStatusCode;

                return respuesta;
            }
            catch
            {
                return false;
            }
        }

        //EDITAR ELEMENTO USER

        public bool Edit(User User)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Users/" + User.id, User).Result;
                var respuesta = response.IsSuccessStatusCode;

                return respuesta;
            }
            catch
            {
                return false;
            }
        }

        //BORRAR ELEMENTO USER

        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Users/" + id).Result;
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