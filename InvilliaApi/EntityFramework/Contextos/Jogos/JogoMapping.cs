using Dominio.Contextos.Jogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Contextos.Jogos
{
    public class JogoMapping : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("TB_JOGOS");

            builder.HasKey(c => c.Id).IsClustered();
            builder.Property(c => c.Id).HasColumnName("ID_JOGO");
            builder.Property(c => c.Nome).HasColumnName("NM_JOGO").IsRequired();
            builder.Property(c => c.Status).HasColumnName("IN_STATUS").IsRequired();
            builder.Property(c => c.TipoJogoId).HasColumnName("IN_TIPO_JOGO").IsRequired();
            builder.Property(c => c.SituacaoId).HasColumnName("IN_SITUACAO").IsRequired();
            builder.Property(c => c.TipoPlataformaId).HasColumnName("IN_TIPO_PLATAFORMA").IsRequired();

            builder.HasOne(j => j.TipoJogo)
                   .WithMany(j => j.TipoDeJogo)
                   .HasForeignKey(j => j.TipoJogoId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.Situacao)
                   .WithMany(j => j.SituacaoDeJogo)
                   .HasForeignKey(j => j.SituacaoId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.TipoPlataforma)
                   .WithMany(j => j.TipoDePlataforma)
                   .HasForeignKey(j => j.TipoPlataformaId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
