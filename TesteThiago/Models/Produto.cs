using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TesteThiago.Models
{

    public class Produto
    {
        [Key]
        [Required(ErrorMessage = "O código é obrigatório.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo de unidade é obrigatório.")]
        public int CodTipoUnidade { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        public int QtdEstoque { get; set; }

        public string Observacao { get; set; }
  
    }

}
