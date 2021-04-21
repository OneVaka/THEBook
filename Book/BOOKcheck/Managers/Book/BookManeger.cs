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
        private BookContext context;

        public BookManeger(BookContext context)
        {
            this.context = context;
        }
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
            return await context.Book.Where(r => r.Rating.WorldRating >= rait1).Where(r => r.Rating.WorldRating <= rait2).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }

        public async Task<ICollection<Storage.Entity.Book>> GetRandomBook()
        {
            Random ran = new Random();
            var num = ran.Next(1, context.Book.Max(st => st.Id));
            return await context.Book.Where(bk => bk.Id == num).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToListAsync();
        }
    }


}
