using Microsoft.EntityFrameworkCore;

namespace OMS.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProducts>()
                .HasKey(p => new {p.OrderId, p.ProductId});

            modelBuilder.Entity<OrderProducts>().HasData(
                new OrderProducts
                { 
                    OrderId = 1,
                    ProductId = 1
                },
                new OrderProducts
                { 
                    OrderId = 2,
                    ProductId = 4
                },
                new OrderProducts
                {
                    OrderId = 2,
                    ProductId = 5
                }, 
                new OrderProducts
                {
                    OrderId = 3,
                    ProductId = 2
                },
                new OrderProducts
                {
                    OrderId = 3,
                    ProductId = 3
                });

            modelBuilder.Entity<Shared.Client>().HasData(
                new Shared.Client
                {
                    Id = 1,
                    Name = "Hubert",
                    Surname = "Buczynski",
                },
                new Shared.Client
                {
                    Id = 2,
                    Name = "Alicja",
                    Surname = "Przybleda",
                });

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = "wisniowa",
                    PostalCode = "02-765",
                    City = "Warszawa",
                    BuildingNumber = 7,
                    ApartmentNumer = 88,
                    Country = "Poland"
                },
                new Address
                {
                    Id = 2,
                    Street = "morelowa",
                    PostalCode = "03-833",
                    City = "Bialystok",
                    BuildingNumber = 18,
                    Country = "Poland"
                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                { 
                    Id = 1,
                    Name = "gril elektryczny ciepla parowa x2137 |Januszex"
                },
                new Product
                {
                    Id = 2,
                    Name = "iphone 13 | 64GB"
                },
                new Product
                {
                    Id = 3,
                    Name = "airpods pro 2"
                },
                new Product
                {
                    Id = 4,
                    Name = "xbox xs 1TB"
                },
                new Product
                {
                    Id = 5,
                    Name = "xbox pad"
                }
                );
            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Name = "awaiting payment",
                    Url = "awaiting_payment"
                },
                new Status
                {
                    Id = 2,
                    Name = "ready to send",
                    Url = "ready_to_send"
                },
                 new Status
                 {
                     Id = 3,
                     Name = "payment failed",
                     Url = "payment_failed"
                 },
                new Status
                {
                    Id = 4,
                    Name = "payment accepted",
                    Url = "payment_accepted"
                },
                new Status
                {
                    Id = 5,
                    Name = "sent",
                    Url = "sent"
                },
                new Status
                {
                    Id = 6,
                    Name = "delivered",
                    Url = "delivered"
                },
                new Status
                {
                    Id = 7,
                    Name = "returned",
                    Url = "returned"
                },
                new Status
                {
                    Id = 8,
                    Name = "arrived",
                    Url = "arrived"
                },
                new Status
                {
                    Id = 9,
                    Name = "condition assessment",
                    Url = "condtion_assessment"
                },
                new Status
                {
                    Id = 10,
                    Name = "refund",
                    Url = "refund"
                }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Date = DateTime.Now,
                    ClientId = 1,
                    StatusId = 1,
                    AddressId = 1,
                },
                new Order
                {
                    Id = 2,
                    Date = DateTime.Now,
                    ClientId = 2,
                    StatusId = 2,
                    AddressId = 2,
                },

                new Order
                {
                    Id = 3,
                    Date = DateTime.Now,
                    ClientId = 1,
                    StatusId = 1,
                    AddressId = 1,
                });
        }
        // SQL table of orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shared.Client> Clients { get; set; }  
        public DbSet<Address> Address { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
