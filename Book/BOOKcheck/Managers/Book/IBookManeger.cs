using System;
using System.Collections.Generic;
namespace BOOKcheck.Storage.Entity
{
    public interface IBookManeger
    {
        ICollection<Book> GetAll();

        ICollection<Book> GetBook(int id);

        ICollection<Book> GetAutor();

        ICollection<Book> GetGenre();
    }
}
