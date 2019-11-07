using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZajazdURosanny.ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string Description { get; set; }
    }
}
