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
        #endregion

        #region Configurações
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        }
        #endregion
    }
}
