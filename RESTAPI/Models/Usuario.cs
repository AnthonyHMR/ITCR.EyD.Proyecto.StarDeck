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
        public int contrasena { get; set; }
        public string? Imagen { get; set; }
    }
}
