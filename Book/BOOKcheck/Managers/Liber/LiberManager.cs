using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKcheck.Storage;
using BOOKcheck.Storage.Lib;
using Microsoft.EntityFrameworkCore;


namespace BOOKcheck.Managers.Liber
{
    public class LiberManager : ILiberManager
    {
        private UniversalContext context;

        public LiberManager(UniversalContext context)
        {
            this.context = context;
        }

        //pageFinish не должен быть null!!

        //удаляет книгу из End
        public async Task<int> RemoveBookEnd(int IdBook,int IdUser)
        {
            int p=0;
            var end = await context.EndRead.FirstOrDefaultAsync(b => b.IdBook == IdBook && b.IdUserLiber == IdUser); //должна быть книга из библиотеки определенного пользователя
            if (end != null)
            {
                var pageEnd = await context.Page.FirstOrDefaultAsync(pg => pg.Id == end.IdPage);

                if (pageEnd != null) {
                    p = pageEnd.Number;
                    context.Page.Remove(pageEnd);
                }
                context.EndRead.Remove(end);
                await context.SaveChangesAsync();
            }
            return p;
        }

        //удаляет книгу из Finish
        public async Task<int> RemoveBookFinish(int IdBook, int IdUser)
        {
            int p = 0;
            var finish = await context.FinishRead.FirstOrDefaultAsync(b => b.IdBook == IdBook && b.IdUserLiber == IdUser);
            if (finish != null)
            {
                var pageFinish = await context.Page.FirstOrDefaultAsync(pg => pg.Id == finish.IdPage);

                if (pageFinish != null) { 
                     p = pageFinish.Number;
                    context.Page.Remove(pageFinish);
                }
                context.FinishRead.Remove(finish);
                await context.SaveChangesAsync();
            }
            return p;
        }

        //удаляет книгу из Now
        public async Task<int> RemoveBookNow(int IdBook, int IdUser)
        {
            int p = 0;
            var now = await context .NowRead.FirstOrDefaultAsync(b => b.IdBook == IdBook && b.IdUserLiber == IdUser);
            if (now != null)
            {
                var pageNow = await context.Page.FirstOrDefaultAsync(pg => pg.Id == now.IdPage);

                if (pageNow != null)
                {
                    p = pageNow.Number;
                    context.Page.Remove(pageNow);
                }

                context.NowRead.Remove(now);
                await context.SaveChangesAsync();
            }
            return p;
        }

        //удаляет книгу из Want
        public async Task<int> RemoveBookWant(int IdBook, int IdUser)
        {
            int p = 0;
            var want = await context.WantRead.FirstOrDefaultAsync(b => b.IdBook == IdBook && b.IdUserLiber == IdUser);

            if (want != null)
            {
                var pageWant =await context.Page.FirstOrDefaultAsync(pg => pg.Id == want.IdPage);

                if (pageWant != null)
                {
                    p = pageWant.Number;
                    context.Page.Remove(pageWant);
                }

                context.WantRead.Remove(want);
                await context.SaveChangesAsync();
            }
            return p;
        }

        //просто удаляет кингу по Id книге
        public  async Task RemoveBook(int IdUser, int IdBook)
        {
            var liber = Proverka(IdUser);
           
            if (liber != null)
            {
                var f = await BookCategory(IdUser, IdBook);

                switch (f)
                {
                    case 1:
                     await RemoveBookEnd(IdBook, IdUser);
                        break;
                    case 2:
                        await RemoveBookFinish(IdBook, IdUser);
                        break;
                    case 3:
                        await RemoveBookNow(IdBook, IdUser);
                        break;
                    case 4:
                        await RemoveBookWant(IdBook, IdUser);
                        break;

                    default:
                        break;
                }
            }
        }

        //добавление книги в любую категорию 
        public async Task AddBookLiber(int IdUser, int IdBook,int flagLiber)
        {
            var l = Proverka(IdUser);
            int f=0,p=0;

            if (l != null)
            {
                f = await BookCategory(IdUser, IdBook);
                
                if (f != 0)
                {
                    switch (f)
                    {
                        case 1:
                            p = await RemoveBookEnd(IdBook, IdUser);
                            break;

                        case 2:
                            p = await RemoveBookFinish(IdBook, IdUser);
                            break;

                        case 3:
                            p = await RemoveBookNow(IdBook, IdUser);
                            break;

                        case 4:
                            p = await RemoveBookWant(IdBook, IdUser);
                            break;

                        default:
                            break;
                    }
                }

                switch (flagLiber)
                {
                    case 1:
                      await  AddBookEnd(IdUser, IdBook, p,f);
                        break;

                    case 2:
                      await  AddBookFinish(IdUser, IdBook, p,f);
                        break;

                    case 3:
                      await AddBookNow(IdUser, IdBook, p);
                        break;

                    case 4:
                      await  AddBookWant(IdUser, IdBook, p);
                        break;

                    default:
                        break;

                }
            }
                
        }


        //добавить страницу
        public async Task<int> AddPage(int numberPage)
        {
            Page page = new Page();
            page.Number = numberPage;
            await context.Page.AddAsync(page);
            await context.SaveChangesAsync();

            return page.Id;
        }

        //добавить книгу в NowRead
        public async Task AddBookNow(int IdUser, int IdBook,int numberPage)
        {
            int idPage = await AddPage(numberPage);

            NowRead now = new NowRead();
            now.IdBook = IdBook;
            now.IdPage = idPage;
            now.IdUserLiber = IdUser;
            now.Page = await context.Page.FirstOrDefaultAsync(p => p.Id == idPage);
            now.Book = await context.Book.FirstOrDefaultAsync(b => b.Id == IdBook);
            now.UserLiber = await context.UserLiber.FirstOrDefaultAsync(u => u.Id == IdUser);

            await context.NowRead.AddAsync(now);
            await context.SaveChangesAsync();

        }

        //добавить книгу в FinishRead
        public async Task AddBookFinish(int IdUser, int IdBook, int numberPage,int rate)
        {
            int idPage = await AddPage(numberPage);

            await ChangeOurRating(IdBook,rate);

            FinishRead finish = new FinishRead();
            finish.IdBook = IdBook;
            finish.IdPage = idPage;
            finish.IdUserLiber = IdUser;
            finish.Page = await context.Page.FirstOrDefaultAsync(p => p.Id == idPage);
            finish.Book = await context.Book.FirstOrDefaultAsync(b => b.Id == IdBook);
            finish.UserLiber = await context.UserLiber.FirstOrDefaultAsync(u => u.Id == IdUser);

            await context.FinishRead.AddAsync(finish);
            await context.SaveChangesAsync();

        }

        //добавить книгу в WantRead
        public async Task AddBookWant(int IdUser, int IdBook, int numberPage)
        {
            int idPage = await AddPage(numberPage);

            WantRead want = new WantRead();
            want.IdBook = IdBook;
            want.IdPage = idPage;
            want.IdUserLiber = IdUser;
            want.Page = await context.Page.FirstOrDefaultAsync(p => p.Id == idPage);
            want.Book = await context.Book.FirstOrDefaultAsync(b => b.Id == IdBook);
            want.UserLiber = await context.UserLiber.FirstOrDefaultAsync(u => u.Id == IdUser);

            await context.WantRead.AddAsync(want);
            await context.SaveChangesAsync();

        }

        //добавить книгу в EndRead
        public async Task AddBookEnd(int IdUser, int IdBook, int numberPage,int rate)
        {
            int idPage = await AddPage(numberPage);

            await ChangeOurRating(IdBook, rate);

            EndRead end = new EndRead();
            end.IdBook = IdBook;
            end.IdPage = idPage;
            end.IdUserLiber = IdUser;
            end.Page = await context.Page.FirstOrDefaultAsync(p => p.Id == idPage);
            end.Book = await context.Book.FirstOrDefaultAsync(b => b.Id == IdBook);
            end.UserLiber = await context.UserLiber.FirstOrDefaultAsync(u => u.Id == IdUser);

            await context.EndRead.AddAsync(end);
            await context.SaveChangesAsync();

        }

        // проверка на User
        public IQueryable<Storage.Lib.UserLiber> Proverka(int IdUser)
        {
            var p = context.UserLiber.Where(t => t.Id == IdUser);

            return p;
        }

        //поиск где находится книга возвращает флаг флаги смотреть в классе UserLiber
        public async Task<int> BookCategory(int IdUser, int IdBook)
        {
            int f = 0;

            var userLib = Proverka(IdUser);

            if(userLib!=null)
                if (await userLib.FirstOrDefaultAsync(t => t.EndRead.Any(e => e.IdBook == IdBook)) != null)
                    f = 1;
                else
                    if (await userLib.FirstOrDefaultAsync(t => t.FinishRead.Any(e => e.IdBook == IdBook)) != null)
                        f = 2;
                    else
                        if (await userLib.FirstOrDefaultAsync(t => t.NowRead.Any(e => e.IdBook == IdBook)) != null)
                            f = 3;
                        else
                            if (await userLib.FirstOrDefaultAsync(t => t.WantRead.Any(e => e.IdBook == IdBook)) != null)
                                f = 4;

            return f;
        }

        //изменение номера страницы
        public async Task ChangePageNumber(int IdBook, int IdLiber, int PageNumber)
        {
            var UserPageNuber = await context.NowRead.Where(r => r.IdUserLiber == IdLiber && r.IdBook == IdBook).Include(pg => pg.Page).SingleOrDefaultAsync();

            if (UserPageNuber != null)
            {
                UserPageNuber.Page.Number = PageNumber;
                await context.SaveChangesAsync();
            }
        }

        //изменение рейтинга
        public async Task ChangeOurRating(int IdBook, double appraisal)
        {
            var UserRating = await context.Book.Where(r => r.Id == IdBook).Include(st => st.Rating).SingleOrDefaultAsync();

            if (UserRating != null)
            {


                if (UserRating.Rating.OurRating == 0)
                    UserRating.Rating.OurRating = appraisal;
                else
                    UserRating.Rating.OurRating = ((UserRating.Rating.OurRating + appraisal) / 2);
                await context.SaveChangesAsync();
            }
        }


        public async Task<ICollection<UserLiber>> GetUserLib(int choice, string userLogin)
        {


            var user = await context.Person.FirstOrDefaultAsync(st => st.Login == userLogin);

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
