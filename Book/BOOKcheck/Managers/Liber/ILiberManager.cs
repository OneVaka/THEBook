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
        public void ChangePageNumber(int IdBook, int IdLiber, int PageNumber);

        public void ChangeOurRating(int IdBook, double appraisal);

        //определяет где книга
        public int BookCategory(int IdUser, int IdBook);

        //просто удаляет кингу по Id книге
        public void RemoveBook(int IdUser, int IdBook);

        //удаляет книгу из End
        public int RemoveBookEnd(int IdBook, int IdUser);

        //удаляет книгу из Finish
        public int RemoveBookFinish(int IdBook, int IdUser);

        //удаляет книгу из Now
        public int RemoveBookNow(int IdBook, int IdUser);

        //удаляет книгу из Want
        public int RemoveBookWant(int IdBook, int IdUser);

        //добавление книги в любую категорию 
        public void AddBookLiber(int IdUser, int IdBook, int flagLiber);

        //добавление книг
        public void AddBookEnd(int IdUser, int IdBook, int numberPage);

        public void AddBookWant(int IdUser, int IdBook, int numberPage);

        public void AddBookFinish(int IdUser, int IdBook, int numberPage);

        public void AddBookNow(int IdUser, int IdBook, int numberPage);

        //добавление страницы
        public int AddPage(int numberPage);
    }
}
