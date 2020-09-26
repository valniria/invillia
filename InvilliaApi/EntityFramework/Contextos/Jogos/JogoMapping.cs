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

            builder.HasKey(j => j.Id).IsClustered();
            builder.Property(j => j.Id).HasColumnName("ID_JOGO");
            builder.Property(j => j.Nome).HasColumnName("NM_JOGO").IsRequired();
            builder.Property(j => j.Status).HasColumnName("IN_STATUS").IsRequired();
            builder.Property(j => j.TipoJogoId).HasColumnName("IN_TIPO_JOGO").IsRequired();
            builder.Property(j => j.SituacaoId).HasColumnName("IN_SITUACAO").IsRequired();
            builder.Property(j => j.TipoPlataformaId).HasColumnName("IN_TIPO_PLATAFORMA").IsRequired();
            builder.Property(j => j.UsuarioId).HasColumnName("ID_USUARIO");

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

            builder.HasOne(j => j.UsuarioQueEstaComOJogo)
                   .WithMany(j => j.UsuarioComJogo)
                   .HasForeignKey(j => j.UsuarioId)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasIndex(j => j.UsuarioId);
        }
    }
}
