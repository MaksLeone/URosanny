using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZajazdURosanny.Models
{
    [Table("Menu")]
    public class MenuModel
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
