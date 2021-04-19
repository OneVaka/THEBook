using System;
using BOOKcheck.Storage.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BOOKcheck.Storage
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }
           
        public DbSet<Genre> Genre { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public BookContext (DbContextOptions<BookContext> options):base (options)
        {

        }

    }
}
