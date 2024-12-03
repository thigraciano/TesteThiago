using Microsoft.AspNetCore.Mvc.Rendering;

namespace TesteThiago.Models
{
    public class ProdutoViewModel
    {
        public Produto NovoProduto { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<SelectListItem> TiposUnidade { get; set; }


    }
}
