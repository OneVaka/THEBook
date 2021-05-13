using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKcheck.Storage;
using BOOKcheck.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace BOOKcheck.Managers.Book
{
    public class BookManeger : IBookManeger
    {
        private UniversalContext context;

        public BookManeger(UniversalContext context)
        {
            this.context = context;
        }



        public async Task<ICollection<Storage.Entity.Book>> GetS(string nameAutor, int genreId, double rait1, double rait2, int sortVal)
        {
            var f = context.Book.Where(b => b.Id > 0);
            
            if (nameAutor != null)
                f = GetAutorT(nameAutor, f);

            if (genreId != 0)
                f = GetGenreT(genreId, f);

            if ((rait1 != -1) && (rait2 != -1))
                f = PridelRatingT(rait1, rait2, f);

            if (sortVal == 2)
                f = UpRatingT(f);

            if (sortVal == 1)
                f = DownRatingT(f);


            return await f.Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }

        //поиск по автору
        public IQueryable<Storage.Entity.Book> GetAutorT(string nameAutor, IQueryable<Storage.Entity.Book> con)
        {
            return con.Where(s => s.Author.Name == nameAutor);
        }
        //поиск книги по названию
        public IQueryable<Storage.Entity.Book> GetBookT(string nameBook, IQueryable<Storage.Entity.Book> con)
        {
            return con.Where(bk => bk.Name == nameBook);
        }
        //поиск по жанру
        public IQueryable<Storage.Entity.Book> GetGenreT(int id, IQueryable<Storage.Entity.Book> con)
        {
            return con.Where(bk => bk.IdGenre == id);
        }
        //сортировка по возрастанию
        public IQueryable<Storage.Entity.Book> DownRatingT(IQueryable<Storage.Entity.Book> con)
        {
            return con.OrderBy(r => r.Rating.WorldRating);
        }
        //сортировка по убыванию
        public IQueryable<Storage.Entity.Book> UpRatingT(IQueryable<Storage.Entity.Book> con)
        {
            return con.OrderByDescending(r => r.Rating.WorldRating);
        }
        //взятие промежутка
        public IQueryable<Storage.Entity.Book> PridelRatingT(double rait1, double rait2, IQueryable<Storage.Entity.Book> con)
        {
            if (rait1 == 0 && rait2 == 0)
                return con.Where(r => r.Rating.WorldRating >= 0).Where(r => r.Rating.WorldRating <= 10);



            return con.Where(r => r.Rating.WorldRating >= rait1).Where(r => r.Rating.WorldRating <= rait2);
        }

        ///////////////////////





        //вывод всей библиотеки
        public async Task<ICollection<Storage.Entity.Book>> GetAll()
        {
            return await context.Book.Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }

        //поиск по автору
        public async Task<ICollection<Storage.Entity.Book>> GetAutor(string name)
        {
            return await context.Book.Where(s => s.Author.Name == name).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }
        //поиск книги по названию
        public async Task<ICollection<Storage.Entity.Book>> GetBook(string name)
        {
            return await context.Book.Where(bk => bk.Name == name).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }
        //поиск по жанру
        public async Task<ICollection<Storage.Entity.Book>> GetGenre(int id)
        {
             if (id == 0)
                return await GetAll();
        
            return await context.Book.Where(bk => bk.IdGenre == id).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }
        //сортировка по возрастанию
        public async Task<ICollection<Storage.Entity.Book>> DownRating()
        {
            return await context.Book.OrderBy(r => r.Rating.WorldRating).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }
        //сортировка по убыванию
        public async Task<ICollection<Storage.Entity.Book>> UpRating()
        {
            return await context.Book.OrderByDescending(r => r.Rating.WorldRating).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }
        //взятие промежутка
        public async Task<ICollection<Storage.Entity.Book>> PridelRating(double rait1, double rait2)
        {
             if(rait1==0 && rait2==0)
                return await context.Book.Where(r => r.Rating.WorldRating >= 0).Where(r => r.Rating.WorldRating <= 10).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();        
        
            return await context.Book.Where(r => r.Rating.WorldRating >= rait1).Where(r => r.Rating.WorldRating <= rait2).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }
        //поиск по ID книги
        public async Task<Storage.Entity.Book> GetBookById(int Id)
        {
            //return await context.Book.Where(bk => bk.Id == Id).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
            Storage.Entity.Book book = null;
            try
            {
                book = await context.Book.Where(book => book.Id == Id).Include(book => book.Author).Include(book => book.Genre).Include(book => book.Rating).SingleAsync(); 
            }
            catch (Exception)
            {
                return null;
            }

            return book;
        }

    }


}
