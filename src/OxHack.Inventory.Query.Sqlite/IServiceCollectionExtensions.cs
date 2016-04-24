﻿using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OxHack.Inventory.Query.Repositories;
using OxHack.Inventory.Query.Sqlite.Repositories;

namespace OxHack.Inventory.Query.Sqlite
{
	public static class IServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection @this, IConfigurationRoot configuration)
        {
            @this
                .AddEntityFramework()
                .AddSqlite();

            var connectionString = configuration["Production:SqliteReadModelConnectionString"];
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite(connectionString);

            @this.AddSingleton<DbContextOptions>(sp => optionsBuilder.Options);
            @this.AddTransient<IItemRepository, ItemRepository>();
		}
    }
}
