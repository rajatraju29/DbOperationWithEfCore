﻿// <auto-generated />
using System;
using DbOperationsForEfCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbOperationsForEfCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbOperationsForEfCore.Data.Author", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPages")
                        .HasColumnType("int");

                    b.Property<int?>("Statusid")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("Statusid");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.BookPrice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Bookid")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Bookid");

                    b.HasIndex("CurrencyId");

                    b.ToTable("BookPrices");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Currency", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Description = "INDIAN INR",
                            Title = "INR"
                        },
                        new
                        {
                            id = 2,
                            Description = "Dollar",
                            Title = "Dollar"
                        },
                        new
                        {
                            id = 3,
                            Description = "Euro",
                            Title = "Euro"
                        },
                        new
                        {
                            id = 4,
                            Description = "Dinar",
                            Title = "Dinar"
                        });
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Language", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Description = "Hindi",
                            Title = "Hindi"
                        },
                        new
                        {
                            id = 2,
                            Description = "Tamil",
                            Title = "Tamil"
                        },
                        new
                        {
                            id = 3,
                            Description = "Punjabi",
                            Title = "Punjabi"
                        },
                        new
                        {
                            id = 4,
                            Description = "Urdu",
                            Title = "Urdu"
                        });
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Status", b =>
                {
                    b.Property<int>("Statusid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Statusid"));

                    b.Property<string>("StatusDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Statusid");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("profileid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Book", b =>
                {
                    b.HasOne("DbOperationsForEfCore.Data.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("DbOperationsForEfCore.Data.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbOperationsForEfCore.Data.Status", "Status")
                        .WithMany("Books")
                        .HasForeignKey("Statusid");

                    b.Navigation("Author");

                    b.Navigation("Language");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.BookPrice", b =>
                {
                    b.HasOne("DbOperationsForEfCore.Data.Book", "Book")
                        .WithMany()
                        .HasForeignKey("Bookid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbOperationsForEfCore.Data.Currency", "Currency")
                        .WithMany("BookPrice")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Profile", b =>
                {
                    b.HasOne("DbOperationsForEfCore.Data.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("DbOperationsForEfCore.Data.Profile", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Currency", b =>
                {
                    b.Navigation("BookPrice");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Language", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.Status", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DbOperationsForEfCore.Data.User", b =>
                {
                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
