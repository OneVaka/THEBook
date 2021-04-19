using System;
using System.Collections.Generic;
using BOOKcheck.Storage.Entity;

namespace BOOKcheck.Storage
{
    public class Exampl
    {
        public List<Author> Author { get; set; }

        public List<Genre> Genre { get; set; }

        public List<Book> Book { get; set; }

        /*
        public Exampl()
        {
            Author = new List<Author>();
            Genre = new List<Genre>();
            Book = new List<Book>();

            var author1 = new Author(Guid.NewGuid(), "автор 1", "описание 1");
            var author2 = new Author(Guid.NewGuid(), "автор 2", "описание 2");
            var author3 = new Author(Guid.NewGuid(), "автор 3", "описание 3");

            Author.Add(author1);
            Author.Add(author2);
            Author.Add(author3);

            var genre1 = new Genre(Guid.NewGuid(), "жанр 1", "описание 1");
            var genre2 = new Genre(Guid.NewGuid(), "жанр 2", "описание 2");
            var genre3 = new Genre(Guid.NewGuid(), "жанр 3", "описание 3");

            Genre.Add(genre1);
            Genre.Add(genre2);
            Genre.Add(genre3);

            Book.Add(new Book(Guid.NewGuid(), "книга 1", genre1, author1, 1999, 8.9m));
            Book.Add(new Book(Guid.NewGuid(), "книга 2", genre1, author2, 2000, 5.6m));
            Book.Add(new Book(Guid.NewGuid(), "книга 3", genre2, author3, 1946, 7.9m));
            Book.Add(new Book(Guid.NewGuid(), "книга 4", genre2, author1, 1976, 10.0m));
            Book.Add(new Book(Guid.NewGuid(), "книга 5", genre3, author3, 1834, 9.9m));
            Book.Add(new Book(Guid.NewGuid(), "книга 6", genre3, author2, 2020, 6.6m));
        }
        */
    }
}
