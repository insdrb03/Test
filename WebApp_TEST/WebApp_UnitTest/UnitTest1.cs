using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp_TEST.Models;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Net;

namespace WebApp_TEST_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private IEnumerable<User> listUsers_ = new List<User>();

        [TestMethod]
        public void Check_Login()
        {
            User usr = new User();
            usr.Username = "insdrb03";
            usr.Password = "21081988";

            var listUsers = getAllUsers();

            var result = listUsers.Where(u => u.Username.Equals(usr.Username) && u.Password.Equals(usr.Password)).FirstOrDefault();

            Assert.IsNotNull(result);
        }


        public IEnumerable<User> getAllUsers()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:65240/api/");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("Users").Result;
            if (response.IsSuccessStatusCode)
            {
                listUsers_ = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

            }

            return listUsers_;
        }


        [TestMethod]
        public void Check_Roles()
        {
            var client = new HttpClient(); 

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:65240/api/Roles"),
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void Check_EditUser()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:65240/api/Users/1"),
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }



        [TestMethod]
        public void Check_CreateUser()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:65240/api/");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };

            User user = new User();
            user.Username = "TEST";
            user.Password = "TEST";
            user.RoleCode = "ADMIN";

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("Users", user).Result;
            var respuesta = response.IsSuccessStatusCode;

        }


    }
}
