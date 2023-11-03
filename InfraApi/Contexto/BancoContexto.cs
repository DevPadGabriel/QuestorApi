//using DominioApi.Entidades;
//using System.Data.Entity.ModelConfiguration;

//namespace InfraApi.Contexto
//{
//    public class BancoContexto : EntityTypeConfiguration<Banco>
//    {
//        protected void Postgres()
//        {
//            HasKey(a => a.Id);
//            Property(a => a.NomeBanco).HasMaxLength(80);
//            Property(a => a.CodigoBanco).HasMaxLength(30);
//            Property(a => a.PercentualJuros).HasPrecision(5, 2);
//        }
//    }
//}
