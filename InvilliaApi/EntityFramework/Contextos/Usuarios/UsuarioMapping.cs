using Dominio.Contextos.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Contextos.Usuarios
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder.HasKey(c => c.Id).IsClustered();
            builder.Property(c => c.Id).HasColumnName("ID_USUARIO");
            builder.Property(c => c.Nome).HasColumnName("NM_NOME").IsRequired();
            builder.Property(c => c.Status).HasColumnName("IN_STATUS").IsRequired();
            builder.Property(c => c.QuantidadeJogosEmprestados).HasColumnName("IN_QTDE_JOGOS_EMPRESTADOS");
            builder.Property(c => c.Email).HasColumnName("NM_EMAIL").IsRequired();
            builder.Property(c => c.Senha).HasColumnName("NM_SENHA").IsRequired();
            builder.Property(c => c.TipoDeUsuario).HasColumnName("IN_TIPO_USUARIO").IsRequired();
            builder.Property(c => c.Role).HasColumnName("NM_ROLE").IsRequired();


        }
    }
}
