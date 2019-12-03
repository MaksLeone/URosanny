using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZajazdURosanny.Models
{
    [Table("News")]
    public class NewsModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public RoleModel RoleViewModel { get; set; }
    }
}
