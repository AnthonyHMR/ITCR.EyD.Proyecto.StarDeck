using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace RESTAPI.Models
{
    public class Carta
    {
        [Key]
        public string id_carta { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int energia { get; set; }
        public int costo { get; set; }
        public string tipo { get; set; }
        public string raza { get; set; }
        public string imagen { get; set; }
        public string estado { get; set; }

    }
}
