using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOOKcheck.Storage.Entity
{
    public interface IBookManeger
    {
        Task<ICollection<Book>> GetAll();

        Task<ICollection<Book>> GetBook(string name);

        Task<ICollection<Book>> GetAutor(string name);

        Task<ICollection<Book>> GetGenre(int id);

        Task<ICollection<Book>> DownRating();

        Task<ICollection<Book>> UpRating();

        Task<ICollection<Book>> PridelRating(double reit1, double reit2);
    }
}
