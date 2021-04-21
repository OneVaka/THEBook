using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOOKcheck.Managers.Book
{
    public interface IBookManeger
    {
        Task<ICollection<Storage.Entity.Book>> GetAll();

        Task<ICollection<Storage.Entity.Book>> GetBook(string name);

        Task<ICollection<Storage.Entity.Book>> GetAutor(string name);

        Task<ICollection<Storage.Entity.Book>> GetGenre(int id);

        Task<ICollection<Storage.Entity.Book>> DownRating();

        Task<ICollection<Storage.Entity.Book>> UpRating();

        Task<ICollection<Storage.Entity.Book>> PridelRating(double reit1, double reit2);

        Task<ICollection<Storage.Entity.Book>> GetRandomBook();
    }
}
