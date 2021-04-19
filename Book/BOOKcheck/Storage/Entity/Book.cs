using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BOOKcheck.Storage.Entity
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

       
        public string Name { get; set; }

        
        [ForeignKey(typeof(Genre))]
        public int IdGenre { get; set; }
        [OneToOne]
        public Genre Genre { get; set; }

        
        [ForeignKey(typeof(Author))]
        public int IdAuthor { get; set; }
        [OneToOne]
        public Author Author { get; set; }

       
        public int Year { get; set; }

        
        [ForeignKey(typeof(Rating))]
        public int IdRating { get; set; }
        [OneToOne]
        public Rating Rating { get; set; }
    }
}
