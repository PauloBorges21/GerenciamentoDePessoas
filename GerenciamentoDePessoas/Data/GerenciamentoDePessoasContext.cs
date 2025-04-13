using GerenciamentoDePessoas.Converters;
using GerenciamentoDePessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Data
{
    public class GerenciamentoDePessoasContext : DbContext
    {
        /// <summary>
        /// Método chamado automaticamente pelo Entity Framework na construção do modelo.
        /// Aqui você pode configurar regras personalizadas para as entidades e propriedades.
        /// </summary>
        /// <param name="modelBuilder">Objeto usado para configurar o modelo (entidades, propriedades, relacionamentos, etc).</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Loop por cada entidade de entidade no modelo(ex Pessoa)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Pega todas as propriedades dessa entidade que são do tipo DateTime (não nullable)
                var dateTimeProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var property in dateTimeProperties)
                {
                    // Aplica o conversor UtcDateTimeConverter, garantindo que as datas sejam salvas/convertidas em UTC
                    modelBuilder.Entity(entityType.ClrType)  // Obtém a entidade com base no tipo CLR (ex: typeof(Entidade))
                        .Property(property.Name)            // Acessa a propriedade DateTime específica
                        .HasConversion(new UtcDateTimeConverter()); // Aplica o conversor personalizado
                }
            }
            // Chama o método base para garantir que outras configurações padrão sejam aplicadas
            base.OnModelCreating(modelBuilder);
        }
        public GerenciamentoDePessoasContext(DbContextOptions<GerenciamentoDePessoasContext> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
