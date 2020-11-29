using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Makeup2.Web.Models
{
    public class Gama
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name ="Gama")]
       
        public string Tipo { get; set; }
        public ICollection<Maquillaje> Maquillajes { get; set; }
    }
}