using System.ComponentModel.DataAnnotations;

namespace TesteThiago.Models
{
    public class TipoUnidade
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
