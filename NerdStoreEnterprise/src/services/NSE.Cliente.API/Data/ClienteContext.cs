using Microsoft.EntityFrameworkCore;
using NSE.Cliente.API.Models;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Data
{
    public sealed class ClienteContext : DbContext, IUnitOfWork
    {
        public ClienteContext(DbContextOptions<ClienteContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Models.Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteContext).Assembly);
        }

        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }
    }

    //public static class MediatorExtension
    //{
    //    public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
    //    {
    //        var domainEntities = ctx.ChangeTracker
    //            .Entries<Entity>()
    //            .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

    //        var domainEvents = domainEntities
    //            .SelectMany(x => x.Entity.Notificacoes)
    //            .ToList();

    //        domainEntities.ToList()
    //            .ForEach(entity => entity.Entity.LimparEventos());

    //        var tasks = domainEvents
    //            .Select(async (domainEvent) => {
    //                await mediator.PublicarEvento(domainEvent);
    //            });

    //        await Task.WhenAll(tasks);
    //    }
    //}
}
