using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOOKcheck.Managers.Liber
{
    public interface ILiberManager
    {
        ICollection<Storage.Lib.UserLiber> GetAllEnd(int IdUser);

        ICollection<Storage.Lib.UserLiber> GetAllWant(int IdUser);

        ICollection<Storage.Lib.UserLiber> GetAllNow(int IdUser);

        ICollection<Storage.Lib.UserLiber> GetAllFinish(int IdUser);

        public void ChangePageNumber(int IdBook, int IdLiber, int PageNumber);

        public void ChangeOurRating(int IdBook, double appraisal);

        public int BookCategory(int IdUser, int IdBook);

        public void RemoveBook(int IdUser, int IdBook);

        public void AddBookEnd(int IdUser, int IdBook, int numberPage);

        public void AddBookWant(int IdUser, int IdBook, int numberPage);

        public void AddBookFinish(int IdUser, int IdBook, int numberPage);

        public void AddBookNow(int IdUser, int IdBook, int numberPage);

        public int AddPage(int numberPage);
    }
}
