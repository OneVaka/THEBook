using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKcheck.Storage;
using BOOKcheck.Storage.Lib;
using BOOKcheck.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using BOOKcheck.Storage.User;

namespace BOOKcheck.Managers.Liber
{
    public class LiberManager : ILiberManager
    {
        private UniversalContext context;

        public LiberManager(UniversalContext context)
        {
            this.context = context;
        }

        //удаляет книгу из End
        public int RemoveBookEnd(int IdBook, int IdUser)
        {
            int p=0;
            var end = context.EndRead.FirstOrDefault(b => b.IdBook == IdBook && b.IdUserLiber == IdUser);   //должна быть книга из библиотеки определенного пользователя
            if (end != null)
            {
                var pageEnd = context.Page.FirstOrDefault(pg => pg.Id == end.IdPage);

                if (pageEnd != null)
                    context.Page.Remove(pageEnd);
                
                context.EndRead.Remove(end);
                context.SaveChanges();
            }
            return p;
        }

        //pageFinish не должен быть null!!

        //удаляет книгу из Finish
        public int RemoveBookFinish(int IdBook, int IdUser)
        {
            int p = 0;
            var finish = context.FinishRead.FirstOrDefault(b => b.IdBook == IdBook && b.IdUserLiber == IdUser);//&& b.IdUserLiber == IdUser
            
            if (finish != null)
            {
                var pageFinish = context.Page.FirstOrDefault(pg => pg.Id == finish.IdPage);

                if(pageFinish != null) 
                    context.Page.Remove(pageFinish);

                context.FinishRead.Remove(finish);
                context.SaveChanges();
            }
            return p;
        }

        //удаляет книгу из Now
        public int RemoveBookNow(int IdBook, int IdUser)
        {
            int p = 0;
            var now = context.NowRead.FirstOrDefault(b => b.IdBook == IdBook && b.IdUserLiber == IdUser);
            if (now != null)
            {
                var pageNow = context.Page.FirstOrDefault(pg => pg.Id == now.IdPage);

                if(pageNow != null)
                   context.Page.Remove(pageNow);

                context.NowRead.Remove(now);
                context.SaveChanges();
            }
            return p;
        }

        //удаляет книгу из Want
        public int RemoveBookWant(int IdBook,int IdUser)
        {
            int p = 0;
            var want = context.WantRead.FirstOrDefault(b => b.IdBook == IdBook && b.IdUserLiber == IdUser);
            if (want != null)
            {
                var pageWant = context.Page.FirstOrDefault(pg => pg.Id == want.IdPage);
                
                if(pageWant != null)
                    context.Page.Remove(pageWant);

                context.WantRead.Remove(want);
                context.SaveChanges();
            }
            return p;
        }

        //просто удаляет кингу по Id книги
        public void RemoveBook(int IdUser, int IdBook)
        {
            var liber = Proverka(IdUser);
           
            if (liber != null)
            {
                var f = BookCategory(IdUser, IdBook);

                switch (f)
                {
                    case 1:
                        RemoveBookEnd(IdBook,IdUser);
                        break;
                    case 2:
                        RemoveBookFinish(IdBook, IdUser);
                        break;
                    case 3:
                        RemoveBookNow(IdBook, IdUser);
                        break;
                    case 4:
                        RemoveBookWant(IdBook, IdUser);
                        break;

                    default:
                        break;
                }
            }
        }

        //добавить страницу
        public int AddPage(int numberPage)
        {
            Page page = new Page();
            page.Number = numberPage;
            context.Page.Add(page);
            context.SaveChanges();

            return page.Id;
        }

        //добавить книгу в NowRead
        public void AddBookNow(int IdUser, int IdBook,int numberPage)
        {
            int idPage = AddPage(numberPage);

            NowRead now = new NowRead();
            now.IdBook = IdBook;
            now.IdPage = idPage;
            now.IdUserLiber = IdUser;
            now.Page = context.Page.FirstOrDefault(p => p.Id == idPage);
            now.Book = context.Book.FirstOrDefault(b => b.Id == IdBook);
            now.UserLiber = context.UserLiber.FirstOrDefault(u => u.Id == IdUser);

            context.NowRead.Add(now);
            context.SaveChanges();

        }

        //добавить книгу в FinishRead
        public void AddBookFinish(int IdUser, int IdBook, int numberPage)
        {
            int idPage = AddPage(numberPage);

            FinishRead finish = new FinishRead();
            finish.IdBook = IdBook;
            finish.IdPage = idPage;
            finish.IdUserLiber = IdUser;
            finish.Page = context.Page.FirstOrDefault(p => p.Id == idPage);
            finish.Book = context.Book.FirstOrDefault(b => b.Id == IdBook);
            finish.UserLiber = context.UserLiber.FirstOrDefault(u => u.Id == IdUser);

            context.FinishRead.Add(finish);
            context.SaveChanges();

        }

        //добавить книгу в WantRead
        public void AddBookWant(int IdUser, int IdBook, int numberPage)
        {
            int idPage = AddPage(numberPage);

            WantRead want = new WantRead();
            want.IdBook = IdBook;
            want.IdPage = idPage;
            want.IdUserLiber = IdUser;
            want.Page = context.Page.FirstOrDefault(p => p.Id == idPage);
            want.Book = context.Book.FirstOrDefault(b => b.Id == IdBook);
            want.UserLiber = context.UserLiber.FirstOrDefault(u => u.Id == IdUser);

            context.WantRead.Add(want);
            context.SaveChanges();

        }

        //добавить книгу в EndRead
        public void AddBookEnd(int IdUser, int IdBook, int numberPage)
        {
            int idPage = AddPage(numberPage);

            EndRead end = new EndRead();
            end.IdBook = IdBook;
            end.IdPage = idPage;
            end.IdUserLiber = IdUser;
            end.Page = context.Page.FirstOrDefault(p => p.Id == idPage);
            end.Book = context.Book.FirstOrDefault(b => b.Id == IdBook);

            end.UserLiber = context.UserLiber.FirstOrDefault(u => u.Id == IdUser);

            context.EndRead.Add(end);
            context.SaveChanges();

        }

        //поиск где находится книга возвращает флаг флаги смотреть в классе UserLiber
        public int BookCategory(int IdUser, int IdBook)
        {
            int f = 0;

            var bc = Proverka(IdUser);

            if(bc!=null)
                if (bc.FirstOrDefault(t => t.EndRead.Any(e => e.IdBook == IdBook)) != null)
                    f = 1;
                else
                    if (bc.FirstOrDefault(t => t.FinishRead.Any(e => e.IdBook == IdBook)) != null)
                        f = 2;
                    else
                        if (bc.FirstOrDefault(t => t.NowRead.Any(e => e.IdBook == IdBook)) != null)
                            f = 3;
                        else
                            if (bc.FirstOrDefault(t => t.WantRead.Any(e => e.IdBook == IdBook)) != null)
                                f = 4;

            return f;
        }

        //изменение номера страницы
        public void ChangePageNumber(int IdBook, int IdLiber, int PageNumber)
        {
            var UserPageNuber = context.EndRead.FirstOrDefault(r => r.IdUserLiber == IdLiber && r.IdBook == IdBook);

            if (UserPageNuber != null)
            {
                UserPageNuber.Page.Number = PageNumber;
                context.SaveChanges();
            }
        }

        //изменение рейтинга
        public void ChangeOurRating(int IdBook, double appraisal)
        {
            var UserRating = context.Book.FirstOrDefault(r => r.Id == IdBook);

            if (UserRating != null)
            {
                if (UserRating.Rating.OurRating == 0)
                    UserRating.Rating.OurRating = appraisal;
                else
                    UserRating.Rating.OurRating = ((UserRating.Rating.OurRating + appraisal) / 2);
                context.SaveChanges();
            }
        }

        //добавление книги в любую категорию 
        public void AddBookLiber(int IdUser, int IdBook,int flagLiber)
        {
            var l = Proverka(IdUser);
            int f,p=0;

            if (l != null)
            {
                f = BookCategory(IdUser, IdBook);
                
                if (f != 0)
                {
                    switch (f)
                    {
                        case 1:
                            p=RemoveBookEnd(IdBook, IdUser);
                            break;

                        case 2:
                            p=RemoveBookFinish(IdBook, IdUser);
                            break;

                        case 3:
                            p=RemoveBookNow(IdBook, IdUser);
                            break;

                        case 4:
                            p=RemoveBookWant(IdBook, IdUser);
                            break;

                        default:
                            break;
                    }
                }

                switch (flagLiber)
                {
                    case 1:
                        AddBookEnd(IdUser, IdBook, p);
                        break;

                    case 2:
                        AddBookFinish(IdUser, IdBook, p);
                        break;

                    case 3:
                        AddBookNow(IdUser, IdBook, p);
                        break;

                    case 4:
                        AddBookWant(IdUser, IdBook, p);
                        break;

                    default:
                        break;

                }
            }
                
        }
        // проверка на User
        public IQueryable<Storage.Lib.UserLiber> Proverka(int IdUser)
        {
            var p = context.UserLiber.Where(t => t.Id == IdUser);

            return p;
        }




       public async Task<ICollection<UserLiber>> GetUserLib(int choice,string userLogin)
       {


               var user = context.Person.FirstOrDefault(st => st.Login == userLogin);

            switch (choice)
           {
               case 1:
                   return await GetAllNow(user.Id);
                  
               case 2:
                    return await GetAllFinish(user.Id);
                    
               case 3:
                    return await GetAllWant(user.Id);
                    
               case 4:
                    return await GetAllEnd(user.Id);
                   
            }
            return null; 
       
       
       }


        //вывод
        public async Task<ICollection<UserLiber>> GetAllEnd(int IdUser)
        {


            return await Proverka(IdUser)
                                   .Include(end => end.EndRead).ThenInclude(end => end.Book).ThenInclude(book => book.Author)
                                   .Include(end => end.EndRead).ThenInclude(end => end.Book).ThenInclude(book => book.Genre)
                                   .Include(end => end.EndRead).ThenInclude(end => end.Book).ThenInclude(book => book.Rating)
                                   .Include(end => end.EndRead).ThenInclude(end => end.Page).ToListAsync();
        }

       
        //вывод
        public async Task<ICollection<UserLiber>> GetAllFinish(int IdUser)
        {
            return await Proverka(IdUser)
                                   .Include(end => end.FinishRead).ThenInclude(end => end.Book).ThenInclude(book => book.Author)
                                   .Include(end => end.FinishRead).ThenInclude(end => end.Book).ThenInclude(book => book.Genre)
                                   .Include(end => end.FinishRead).ThenInclude(end => end.Book).ThenInclude(book => book.Rating)
                                   .Include(end => end.FinishRead).ThenInclude(end => end.Page).ToListAsync();
        }

        //вывод
        public async Task<ICollection<UserLiber>> GetAllNow(int IdUser)
        {
            return await Proverka(IdUser)
                                   .Include(end => end.NowRead).ThenInclude(end => end.Book).ThenInclude(book => book.Author)
                                   .Include(end => end.NowRead).ThenInclude(end => end.Book).ThenInclude(book => book.Genre)
                                   .Include(end => end.NowRead).ThenInclude(end => end.Book).ThenInclude(book => book.Rating)
                                   .Include(end => end.NowRead).ThenInclude(end => end.Page).ToListAsync();
        }

        //вывод
        public async Task<ICollection<UserLiber>> GetAllWant(int IdUser)
        {
            return await Proverka(IdUser)
                                   .Include(end => end.WantRead).ThenInclude(end => end.Book).ThenInclude(book => book.Author)
                                   .Include(end => end.WantRead).ThenInclude(end => end.Book).ThenInclude(book => book.Genre)
                                   .Include(end => end.WantRead).ThenInclude(end => end.Book).ThenInclude(book => book.Rating)
                                   .Include(end => end.WantRead).ThenInclude(end => end.Page).ToListAsync();
        }


    }
}
