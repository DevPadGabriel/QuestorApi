using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DominioApi.ModelosDtos
{
    public class BoletoDto
    {
        public string? NomePagador { get; set; }
        public string? CpfCnpjPagador { get; set; }
        public string? NomeBeneficiario { get; set; }
        public string? CpfCnpjBeneficiario { get; set; }
        public decimal? Valor { get; set; }
        public DateOnly? DataVencimento { get; set; }

        public string? Observacao { get; set; }
        public int BancoId { get; set; }
    }
}
