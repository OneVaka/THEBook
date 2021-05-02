using System;
using BOOKcheck.Storage.Entity;
using BOOKcheck.Storage.Lib;
using BOOKcheck.Storage.User;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BOOKcheck.Storage
{
    public class UniversalContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }
           
        public DbSet<Genre> Genre { get; set; }

        public DbSet<Rating> Rating { get; set; }
        
        public DbSet<Page> Page { get; set; }

        public DbSet<EndRead> EndRead { get; set; }

        public DbSet<FinishRead> FinishRead { get; set; }

        public DbSet<NowRead> NowRead { get; set; }

        public DbSet<WantRead> WantRead { get; set; }

        public DbSet<UserLiber> UserLiber { get; set; }

        public DbSet<Person> Person { get; set; }

        public UniversalContext (DbContextOptions<UniversalContext> options):base (options)
        {

        }

    }
}
