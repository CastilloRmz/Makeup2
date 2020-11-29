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
        [Display(Name = "Paleta")]
        public ApplicationUser Paletas { get; set; }
        [Display(Name = "Tiempo que caduca")]
        public DateTime  DateTime { get; set; }
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        [Display(Name = "Gama")]
        public int GamaId { get; set; }
        [ForeignKey("GamaId")]
        public Gama Gama { get; set; }
    }
}