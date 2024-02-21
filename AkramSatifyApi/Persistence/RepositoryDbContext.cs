using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;

namespace Persistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<MediaFile> MediaFiles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<DeliveryBoy> DeliveryBoys { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<UserOffer> UserOffers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
    }
}
