using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Role
    {
        public int id { get; set; }
        public string RoleCode { get; set; }
        public string RoleDescription { get; set; }
    }
}