using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    public class Usuario_Tiene_Carta
    {
        [Key, Column(Order = 1)]
        public string id_usuario { get; set; }
        [Key, Column(Order = 2)]
        public string id_carta { get; set; }
    }
}
