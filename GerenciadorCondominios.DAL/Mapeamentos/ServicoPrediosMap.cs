using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Mapeamentos
{
    public class ServicoPrediosMap : IEntityTypeConfiguration<ServicoPredio>
    {
        public void Configure(EntityTypeBuilder<ServicoPredio> builder)
        {
            builder.HasKey(sp => sp.ServicoId);
            builder.Property(sp => sp.ServicoId).IsRequired();
            builder.Property(sp => sp.DataExecucao).IsRequired();

            builder.HasOne(sp => sp.Servico).WithMany(sp => sp.ServicoPredios).HasForeignKey(sp => sp.ServicoId);

            builder.ToTable("ServicoPredios");
        }
    }
}
