using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DominioApi.Entidades
{

    [Table("banco")]
    public class Banco
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nomebanco")]
        public string NomeBanco { get; set; }

        [Required]
        [Column("codigobanco")]
        public string CodigoBanco { get; set; }

        [Required]
        [Column("percentualjuros")]
        public decimal PercentualJuros { get; set; }

        public virtual ICollection<Boleto> Boletos { get; set; }

    }
}
