using Dominio.Contextos.Jogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Contextos.Jogos
{
    public class TipoJogoMapping : IEntityTypeConfiguration<TipoJogo>
    {
        public void Configure(EntityTypeBuilder<TipoJogo> builder)
        {
            builder.ToTable("TB_TIPO_JOGO");

            builder.HasKey(j => j.Id).IsClustered();
            builder.Property(j => j.Id).HasColumnName("ID_TIPO_JOGO");
            builder.Property(j => j.Descricao).HasColumnName("DS_TIPO_JOGO").IsRequired();
        }
    }
}
