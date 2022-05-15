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

        Task<Storage.Entity.Book> GetBookById(int Id);

        Task<ICollection<Storage.Entity.Book>> GetS(string nameAutor, int id, double rait1, double rait2, int sortVal);

        Task<Storage.Entity.Book> GetRandomBook();
    }
}
