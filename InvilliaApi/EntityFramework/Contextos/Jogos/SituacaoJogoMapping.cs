using Dominio.Contextos.Jogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Contextos.Jogos
{
    public class SituacaoJogoMapping : IEntityTypeConfiguration<SituacaoJogo>
    {
        public void Configure(EntityTypeBuilder<SituacaoJogo> builder)
        {
            builder.ToTable("TB_SITUACAO_JOGO");

            builder.HasKey(j => j.Id).IsClustered();
            builder.Property(j => j.Id).HasColumnName("ID_SITUACAO");
            builder.Property(j => j.Descricao).HasColumnName("DS_SITUACAO").IsRequired();
        }
    }
}
