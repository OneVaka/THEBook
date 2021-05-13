using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOOKcheck.Managers.Liber
{
    public interface ILiberManager
    {
        //вывод
        Task<ICollection<Storage.Lib.UserLiber>> GetAllEnd(int IdUser);

        Task<ICollection<Storage.Lib.UserLiber>> GetAllWant(int IdUser);

        Task<ICollection<Storage.Lib.UserLiber>> GetAllNow(int IdUser);

        Task<ICollection<Storage.Lib.UserLiber>> GetAllFinish(int IdUser);

        Task<ICollection<Storage.Lib.UserLiber>> GetUserLib(int choice, string userLogin);
        //измение
        public Task ChangePageNumber(int IdBook, int IdLiber, int PageNumber);

        public Task ChangeOurRating(int IdBook, double appraisal);

        //определяет где книга
        Task<int> BookCategory(int IdUser, int IdBook);

        //просто удаляет кингу по Id книге
        public Task RemoveBook(int IdUser, int IdBook);

        //удаляет книгу из End
        Task<int> RemoveBookEnd(int IdBook, int IdUser);

        //удаляет книгу из Finish
        Task<int> RemoveBookFinish(int IdBook, int IdUser);

        //удаляет книгу из Now
        Task<int> RemoveBookNow(int IdBook, int IdUser);

        //удаляет книгу из Want
        Task<int> RemoveBookWant(int IdBook, int IdUser);

        //добавление книги в любую категорию 
        public Task AddBookLiber(int IdUser, int IdBook, int flagLiber);

        //добавление книг
        public Task AddBookEnd(int IdUser, int IdBook, int numberPage);

        public Task AddBookWant(int IdUser, int IdBook, int numberPage);

        public Task AddBookFinish(int IdUser, int IdBook, int numberPage);

        public Task AddBookNow(int IdUser, int IdBook, int numberPage);

        //добавление страницы
        Task<int> AddPage(int numberPage);
    }
}
