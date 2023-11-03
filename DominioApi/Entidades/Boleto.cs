using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DominioApi.Entidades
{
    [Table("boleto")]
    public class Boleto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nomepagador")]
        public string NomePagador { get; set; }

        [Required]
        [Column("cpfcnpjpagador")]
        public string CpfCnpjPagador { get; set; }

        [Required]
        [Column("nomebeneficiario")]
        public string NomeBeneficiario { get; set; }

        [Required]
        [Column("cpfcnpjbeneficiario")]
        public string CpfCnpjBeneficiario { get; set; }

        [Required]
        [Column("valor")]
        public decimal Valor { get; set; }

        [Required]
        [Column("datavencimento")]
        public DateOnly DataVencimento { get; set; }


        [Column("observacao")]
        public string? Observacao { get; set; }

        [Required]
        [Column("bancoid")]
        public int BancoId { get; set; }

        public virtual Banco Banco { get; set; }
    }
}
