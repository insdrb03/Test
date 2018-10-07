using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_TEST.Models
{
    public class UserModel
    {
        private IEnumerable<User> listUsers = new List<User>();

        public UserModel()
        {
            UserClient uc = new UserClient();
            listUsers = uc.findAll();

            //listUsers.Add(new User { Username = "insdrb03", Password = "21081988", RoleCode = "ADMIN"  });
            //listUsers.Add(new User { Username = "breich", Password = "insdrb03", RoleCode = "PAGE_1" });
            //listUsers.Add(new User { Username = "Scott", Password = "Tiger", RoleCode = "PAGE_2" });
            //listUsers.Add(new User { Username = "Tiger", Password = "Scott", RoleCode = "PAGE_3" });
        }

        public User find_user(string username)
        {
            return listUsers.Where(u => u.Username.Equals(username)).FirstOrDefault();

        }

        public User Login (string username, string password)
        {

            return listUsers.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
        }
    }

    }