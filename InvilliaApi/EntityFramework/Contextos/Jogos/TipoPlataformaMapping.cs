using Dominio.Contextos.Jogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Contextos.Jogos
{
    public class TipoPlataformaMapping : IEntityTypeConfiguration<TipoPlataforma>
    {
        public void Configure(EntityTypeBuilder<TipoPlataforma> builder)
        {
            builder.ToTable("TB_TIPO_PLATAFORMA");

            builder.HasKey(j => j.Id).IsClustered();
            builder.Property(j => j.Id).HasColumnName("ID_PLATAFORMA");
            builder.Property(j => j.Descricao).HasColumnName("DS_PLATAFORMA").IsRequired();
        }
    }
}
