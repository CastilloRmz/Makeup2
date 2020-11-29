using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Makeup2.Web.Models
{
    public class Maquillaje
    {
        public int Id { get; set; }
        public ApplicationUser Paletas { get; set; }
        public DateTime  DateTime { get; set; }
        public string Marca { get; set; }
        public int GamaId { get; set; }
        public Gama Gama { get; set; }
    }
}