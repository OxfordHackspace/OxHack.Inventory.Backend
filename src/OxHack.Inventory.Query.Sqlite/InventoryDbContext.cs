﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OxHack.Inventory.Query.Sqlite.Models;

namespace OxHack.Inventory.Query.Sqlite
{
	internal class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Item>(entity =>
			{
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.ConcurrencyId);
                entity.Property(e => e.Appearance).IsRequired();
				entity.Property(e => e.AssignedLocation).IsRequired();
				entity.Property(e => e.Category).IsRequired();
				entity.Property(e => e.Name).IsRequired();
				entity
					.HasMany(item => item.Photos)
					.WithOne(photo => photo.Item);
			});

			modelBuilder.Entity<Photo>(entity =>
			{
				entity.HasKey(nameof(Photo.Filename), nameof(Photo.ItemId));
				entity
					.HasOne(photo => photo.Item)
					.WithMany(item => item.Photos)
					.HasForeignKey(photo => photo.ItemId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			//modelBuilder.Entity<Category>(entity =>
			//{
			//	entity.HasKey(e => e.Id);
			//	entity
			//		.HasOne<Category>(category => category.Parent)
			//		.WithMany()
			//		.HasForeignKey(category => category.ParentId)
			//		.OnDelete(DeleteBehavior.Restrict);
			//	entity
			//		.HasMany<Item>(category => category.Items)
			//		.WithOne(item => item.Category);
			//});
		}

		internal virtual DbSet<Item> Items
		{
			get; set;
		}

		internal virtual DbSet<Photo> Photos
		{
			get; set;
		}
	}
}
