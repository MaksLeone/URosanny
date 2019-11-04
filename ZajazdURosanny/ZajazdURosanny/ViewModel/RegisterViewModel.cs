using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZajazdURosanny.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, Compare("RepeatPassword")]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }

    }
}
