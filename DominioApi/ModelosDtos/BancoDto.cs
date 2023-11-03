using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DominioApi.ModelosDtos
{
    public class BancoDto
    {
        public string? NomeBanco { get; set; }
        public string? CodigoBanco { get; set; }
        public decimal? PercentualJuros { get; set; }
    }
}