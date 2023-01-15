﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OMS.Server.Data;

#nullable disable

namespace OMS.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230109183210_shit")]
    partial class shit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OMS.Shared.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentNumer")
                        .HasColumnType("int");

                    b.Property<int>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApartmentNumer = 88,
                            BuildingNumber = 7,
                            City = "Warszawa",
                            Country = "Poland",
                            PostalCode = "02-765",
                            Street = "wisniowa"
                        },
                        new
                        {
                            Id = 2,
                            ApartmentNumer = 0,
                            BuildingNumber = 18,
                            City = "Bialystok",
                            Country = "Poland",
                            PostalCode = "03-833",
                            Street = "morelowa"
                        });
                });

            modelBuilder.Entity("OMS.Shared.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfOrders")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "",
                            Name = "Hubert",
                            NumberOfOrders = 0,
                            PhoneNumber = "",
                            Surname = "Buczynski"
                        },
                        new
                        {
                            Id = 2,
                            Email = "",
                            Name = "Alicja",
                            NumberOfOrders = 0,
                            PhoneNumber = "",
                            Surname = "Przybleda"
                        });
                });

            modelBuilder.Entity("OMS.Shared.DeliveryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTypes");
                });

            modelBuilder.Entity("OMS.Shared.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderValue")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ClientId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            ClientId = 1,
                            Date = new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(5984),
                            Deleted = false,
                            OrderValue = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            ClientId = 2,
                            Date = new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6014),
                            Deleted = false,
                            OrderValue = 0,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 1,
                            ClientId = 1,
                            Date = new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6016),
                            Deleted = false,
                            OrderValue = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 1,
                            ClientId = 2,
                            Date = new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6018),
                            Deleted = false,
                            OrderValue = 0,
                            StatusId = 7
                        },
                        new
                        {
                            Id = 77,
                            AddressId = 2,
                            ClientId = 2,
                            Date = new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6020),
                            Deleted = false,
                            OrderValue = 0,
                            StatusId = 4
                        },
                        new
                        {
                            Id = 18,
                            AddressId = 1,
                            ClientId = 1,
                            Date = new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6022),
                            Deleted = false,
                            OrderValue = 0,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("OMS.Shared.OrderProducts", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 4
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 5
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 2
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("OMS.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "gril elektryczny ciepla parowa x2137 |Januszex",
                            Producer = ""
                        },
                        new
                        {
                            Id = 2,
                            Name = "iphone 13 | 64GB",
                            Producer = ""
                        },
                        new
                        {
                            Id = 3,
                            Name = "airpods pro 2",
                            Producer = ""
                        },
                        new
                        {
                            Id = 4,
                            Name = "xbox xs 1TB",
                            Producer = ""
                        },
                        new
                        {
                            Id = 5,
                            Name = "xbox pad",
                            Producer = ""
                        });
                });

            modelBuilder.Entity("OMS.Shared.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "awaiting payment",
                            Url = "awaiting_payment"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ready to send",
                            Url = "ready_to_send"
                        },
                        new
                        {
                            Id = 3,
                            Name = "payment failed",
                            Url = "payment_failed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "payment accepted",
                            Url = "payment_accepted"
                        },
                        new
                        {
                            Id = 5,
                            Name = "sent",
                            Url = "sent"
                        },
                        new
                        {
                            Id = 6,
                            Name = "delivered",
                            Url = "delivered"
                        },
                        new
                        {
                            Id = 7,
                            Name = "returned",
                            Url = "returned"
                        },
                        new
                        {
                            Id = 8,
                            Name = "arrived",
                            Url = "arrived"
                        },
                        new
                        {
                            Id = 9,
                            Name = "condition assessment",
                            Url = "condtion_assessment"
                        },
                        new
                        {
                            Id = 10,
                            Name = "refund",
                            Url = "refund"
                        });
                });

            modelBuilder.Entity("OMS.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OMS.Shared.Order", b =>
                {
                    b.HasOne("OMS.Shared.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMS.Shared.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMS.Shared.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Client");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("OMS.Shared.OrderProducts", b =>
                {
                    b.HasOne("OMS.Shared.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMS.Shared.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OMS.Shared.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
