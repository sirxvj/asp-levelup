﻿// <auto-generated />
using System;
using ConsoleQueries.Data;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleQueries.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "status", new[] { "InReview", "InDelivery", "Completed" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "user_type", new[] { "ADMIN", "CUSTOMER" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConsoleQueries.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

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
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "nameb")
                        .IsUnique();

                    b.ToTable("brand", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.CartItem", b =>
                {
                    b.Property<long>("ProductVariantId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_variant_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

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
                        .HasColumnType("character varying(40)")
                        .HasColumnName("name");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("parent_category_id");

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
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

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
                        .HasColumnType("bytea")
                        .HasColumnName("bytes");

                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("file_name");

                    b.Property<string>("FileType")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("file_type");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("media", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint")
                        .HasColumnName("address_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

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
                        .HasColumnType("bigint")
                        .HasColumnName("product_variant_id");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("ProductVariantId", "OrderId")
                        .HasName("order_items_pkey");

                    b.HasIndex("OrderId");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.OrderTransaction", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("OrderId")
                        .HasName("order_transactions_pkey");

                    b.ToTable("order_transactions", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<short?>("AverageRating")
                        .HasColumnType("smallint")
                        .HasColumnName("average_rating");

                    b.Property<int?>("BrandId")
                        .HasColumnType("integer")
                        .HasColumnName("brand_id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int?>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

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
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("ColorId")
                        .HasColumnType("integer")
                        .HasColumnName("color_id");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int?>("SizeId")
                        .HasColumnType("integer")
                        .HasColumnName("size_id");

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
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("comment");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<short?>("Rating")
                        .HasColumnType("smallint")
                        .HasColumnName("rating");

                    b.Property<string>("Titile")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("titile");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("review", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.ReviewsForProduct", b =>
                {
                    b.Property<string>("Comment")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("comment");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("last_name");

                    b.Property<short?>("Rating")
                        .HasColumnType("smallint")
                        .HasColumnName("rating");

                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("username");

                    b.ToView("reviews_for_product");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Section", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "namese")
                        .IsUnique();

                    b.ToTable("section", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "names")
                        .IsUnique();

                    b.ToTable("size", (string)null);
                });

            modelBuilder.Entity("ConsoleQueries.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone");

                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("username");

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
                        .HasColumnType("smallint")
                        .HasColumnName("section_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.HasKey("SectionId", "CategoryId")
                        .HasName("section_to_category_pkey");

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
                        .HasForeignKey("ParentCategoryId")
                        .HasConstraintName("parent_category_idс");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Media", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Product", "Product")
                        .WithMany("Media")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("media_product_id_fkey");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Order", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("address_idс");

                    b.HasOne("ConsoleQueries.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_idс");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleQueries.Models.OrderItem", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("order_idс");

                    b.HasOne("ConsoleQueries.Models.ProductVariant", "ProductVariant")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductVariantId")
                        .IsRequired()
                        .HasConstraintName("product_variant_idс");

                    b.Navigation("Order");

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("ConsoleQueries.Models.OrderTransaction", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Order", "Order")
                        .WithOne("OrderTransaction")
                        .HasForeignKey("ConsoleQueries.Models.OrderTransaction", "OrderId")
                        .IsRequired()
                        .HasConstraintName("order_idс");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Product", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("brand_idс");

                    b.HasOne("ConsoleQueries.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("category_idс");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ConsoleQueries.Models.ProductVariant", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Color", "Color")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ColorId")
                        .HasConstraintName("color_idс");

                    b.HasOne("ConsoleQueries.Models.Product", "Product")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_idс");

                    b.HasOne("ConsoleQueries.Models.Size", "Size")
                        .WithMany("ProductVariants")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("size_idс");

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ConsoleQueries.Models.Review", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_idс");

                    b.HasOne("ConsoleQueries.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_idс");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SectionToCategory", b =>
                {
                    b.HasOne("ConsoleQueries.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("category_idс");

                    b.HasOne("ConsoleQueries.Models.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .IsRequired()
                        .HasConstraintName("section_idс");
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
