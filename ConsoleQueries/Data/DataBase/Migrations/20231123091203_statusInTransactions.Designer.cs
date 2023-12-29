﻿// <auto-generated />
using System;
using ConsoleQueries.Data;
using ConsoleQueries.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleQueries.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231123091203_statusInTransactions")]
    partial class statusInTransactions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "status", new[] { "in_review", "in_delivery", "completed" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "user_type", new[] { "customer", "admin" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConsoleQueries.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address1")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("country");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "nameb")
                        .IsUnique();

                    b.ToTable("brand", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.CartItem", b =>
                {
                    b.Property<long>("ProductVariantId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductVariantId", "UserId")
                        .HasName("cart_items_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("cart_items", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.HasIndex(new[] { "Name" }, "nameсa")
                        .IsUnique();

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "nameс")
                        .IsUnique();

                    b.ToTable("color", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Bytes")
                        .HasColumnType("bytea");

                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FileType")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("media", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Price")
                        .HasColumnType("integer");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.OrderItem", b =>
                {
                    b.Property<long>("ProductVariantId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductVariantId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.OrderTransaction", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.ToTable("order_transactions", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<short?>("AverageRating")
                        .HasColumnType("smallint");

                    b.Property<int?>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Name" }, "namep")
                        .IsUnique();

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.ProductVariant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("ColorId")
                        .HasColumnType("integer");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("SizeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("product_variant", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<short?>("Rating")
                        .HasColumnType("smallint");

                    b.Property<string>("Titile")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("review", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Section", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "namese")
                        .IsUnique();

                    b.ToTable("section", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "names")
                        .IsUnique();

                    b.ToTable("size", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "emailс")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "phoneс")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("SectionToCategory", b =>
                {
                    b.Property<short>("SectionId")
                        .HasColumnType("smallint");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("SectionId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("section_to_category", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Address", b =>
                {
                    b.HasOne("ConsoleQueries.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleQueries.Models.CartItem", b =>
                {
                    b.HasOne("ConsoleQueries.Models.ProductVariant", "ProductVariant")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductVariantId")
                        .IsRequired()
                        .HasConstraintName("product_variant_idс");

                    b.HasOne("ConsoleQueries.Models.User", "User")
                        .WithMany("CartItems")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("user_idс");

                    b.Navigation("ProductVariant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Category", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Category", "ParentCategory")
                        .WithMany("InverseParentCategory")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Media", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Product", "Product")
                        .WithMany("Media")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Order", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId");

                    b.HasOne("ConsoleQueries.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleQueries.Models.OrderItem", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .IsRequired();

                    b.HasOne("ConsoleQueries.Models.ProductVariant", "ProductVariant")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductVariantId")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("ConsoleQueries.Models.OrderTransaction", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Order", "Order")
                        .WithOne("OrderTransaction")
                        .HasForeignKey("ConsoleQueries.Models.OrderTransaction", "OrderId")
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Product", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("ConsoleQueries.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ConsoleQueries.Models.ProductVariant", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Color", "Color")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ColorId");

                    b.HasOne("ConsoleQueries.Models.Product", "Product")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ProductId");

                    b.HasOne("ConsoleQueries.Models.Size", "Size")
                        .WithMany("ProductVariants")
                        .HasForeignKey("SizeId");

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Review", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId");

                    b.HasOne("ConsoleQueries.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SectionToCategory", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.HasOne("ConsoleQueries.Models.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleQueries.Models.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Category", b =>
                {
                    b.Navigation("InverseParentCategory");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Color", b =>
                {
                    b.Navigation("ProductVariants");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("OrderTransaction");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Product", b =>
                {
                    b.Navigation("Media");

                    b.Navigation("ProductVariants");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ConsoleQueries.Models.ProductVariant", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Size", b =>
                {
                    b.Navigation("ProductVariants");
                });

            modelBuilder.Entity("ConsoleQueries.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CartItems");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
