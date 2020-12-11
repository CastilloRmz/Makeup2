using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Makeup2.Web.Models
{
    public class Maquillaje
    {
        public int Id { get; set; }
        public string ApplicationUser { get; set; }
        [Display(Name = "Paleta")]
        [ForeignKey("ApplicationUser")]
        public ApplicationUser Paletas { get; set; }
        [Display(Name = "Tiempo que caduca")]
        public DateTime  DateTime { get; set; }
        [Display(Name = "Gama")]
        public string Marca { get; set; }
        [Display(Name = "Marcas")]
        public int GamaId { get; set; }
        [ForeignKey("GamaId")]
        [Display(Name = "Gamas")]
        public Gama Gama { get; set; }
    }
}