using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace RESTAPI.Models
{
    public class Usuario
    {
        [Key]
        public string id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string nombre_completo { get; set; }
        public string nacionalidad { get; set; }
        public string contrasena { get; set; }
        public string? imagen { get; set; }
        public string estado { get; set; }
        public int ranking { get; set; }
        public int monedas { get; set; }
    }
}
