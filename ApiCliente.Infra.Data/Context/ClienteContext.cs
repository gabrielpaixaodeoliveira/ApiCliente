using ApiCliente.Domain.Entities;
using ApiCliente.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace ApiCliente.Infra.Data.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }

        #region DbSets


        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        #endregion

        #region Configurações
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        }
        #endregion
    }
}
