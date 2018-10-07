using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp_TEST.Models
{
    public class WebApp_TESTContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApp_TESTContext() : base("name=WebApp_TESTContext")
        {
        }

        public System.Data.Entity.DbSet<WebApp_TEST.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<WebApp_TEST.Models.Role> Roles { get; set; }
    }
}
