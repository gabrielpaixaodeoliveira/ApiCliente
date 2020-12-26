using ApiCliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCliente.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tb_cliente");
            builder.HasKey(p => p.IdCliente);
            builder.HasMany(p => p.Endereco).WithOne().HasForeignKey(x => x.IdCliente);


        }
    }
}
