using System;
using System.Collections.Generic;
namespace BOOKcheck.Storage.Entity
{
    public interface IBookManeger
    {
        ICollection<Book> GetAll();

        ICollection<Book> GetBook(string name);

        ICollection<Book> GetAutor(string name);

        ICollection<Book> GetGenre(int id);

        ICollection<Book> DownRating();

        ICollection<Book> UpRating();

        ICollection<Book> PridelRating(double reit1, double reit2);
    }
}
