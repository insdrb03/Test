using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_TEST.Models
{
    public class User
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Nombre de usuario obligatorio")]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public string RoleCode { get; set; }
    }
}