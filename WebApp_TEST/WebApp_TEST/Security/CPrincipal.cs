using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebApp_TEST.Models;

namespace WebApp_TEST.Security
{
    public class CPrincipal : IPrincipal
    {
        private User User;

        public CPrincipal(User user)
        {
            this.User = user;
            this.Identity = new GenericIdentity(user.Username);
        }

        public IIdentity Identity{get;set;}

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.User.RoleCode.Contains(r));
        }
    }
}