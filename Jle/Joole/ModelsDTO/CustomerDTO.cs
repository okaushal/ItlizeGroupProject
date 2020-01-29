using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Joole.ModelsDTO
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "Mandatory")]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Compare("PASSWORD", ErrorMessage ="Passwords MUST Match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public string FULLNAME { get; set; }
        public string PICTURE { get; set; }
    }
}