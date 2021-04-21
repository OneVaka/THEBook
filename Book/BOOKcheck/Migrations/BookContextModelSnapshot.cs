﻿// <auto-generated />
using System;
using BOOKcheck.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BOOKcheck.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("BOOKcheck.Storage.Entity.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdAuthor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdGenre")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdRating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RatingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("RatingId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Entity.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Entity.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("OurRating")
                        .HasColumnType("REAL");

                    b.Property<double>("WorldRating")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.EndRead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBook")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUserLiber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PageId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserLiberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PageId");

                    b.HasIndex("UserLiberId");

                    b.ToTable("EndRead");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.FinishRead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBook")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUserLiber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PageId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserLiberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PageId");

                    b.HasIndex("UserLiberId");

                    b.ToTable("FinishRead");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.NowRead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBook")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUserLiber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PageId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserLiberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PageId");

                    b.HasIndex("UserLiberId");

                    b.ToTable("NowRead");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.UserLiber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("UserLiber");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.WantRead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBook")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUserLiber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PageId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserLiberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PageId");

                    b.HasIndex("UserLiberId");

                    b.ToTable("WantRead");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Entity.Book", b =>
                {
                    b.HasOne("BOOKcheck.Storage.Entity.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("BOOKcheck.Storage.Entity.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("BOOKcheck.Storage.Entity.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId");

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.EndRead", b =>
                {
                    b.HasOne("BOOKcheck.Storage.Entity.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BOOKcheck.Storage.Lib.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId");

                    b.HasOne("BOOKcheck.Storage.Lib.UserLiber", null)
                        .WithMany("EndRead")
                        .HasForeignKey("UserLiberId");

                    b.Navigation("Book");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.FinishRead", b =>
                {
                    b.HasOne("BOOKcheck.Storage.Entity.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BOOKcheck.Storage.Lib.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId");

                    b.HasOne("BOOKcheck.Storage.Lib.UserLiber", null)
                        .WithMany("FinishRead")
                        .HasForeignKey("UserLiberId");

                    b.Navigation("Book");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.NowRead", b =>
                {
                    b.HasOne("BOOKcheck.Storage.Entity.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BOOKcheck.Storage.Lib.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId");

                    b.HasOne("BOOKcheck.Storage.Lib.UserLiber", null)
                        .WithMany("NowRead")
                        .HasForeignKey("UserLiberId");

                    b.Navigation("Book");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.WantRead", b =>
                {
                    b.HasOne("BOOKcheck.Storage.Entity.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BOOKcheck.Storage.Lib.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId");

                    b.HasOne("BOOKcheck.Storage.Lib.UserLiber", null)
                        .WithMany("WantRead")
                        .HasForeignKey("UserLiberId");

                    b.Navigation("Book");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("BOOKcheck.Storage.Lib.UserLiber", b =>
                {
                    b.Navigation("EndRead");

                    b.Navigation("FinishRead");

                    b.Navigation("NowRead");

                    b.Navigation("WantRead");
                });
#pragma warning restore 612, 618
        }
    }
}
