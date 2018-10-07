using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_TEST.Models
{
    public class Role
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Código de Rol")]
        public string RoleCode { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción")]
        public string RoleDescription { get; set; }
    }
}