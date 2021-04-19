using System;
using System.Collections.Generic;
using System.Linq;
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
        public ICollection<Storage.Entity.Book> GetAll()
        {
            return context.Book.Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }

        //поиск по автору
        public ICollection<Storage.Entity.Book> GetAutor(string name)
        {
            return context.Book.Where(s => s.Author.Name == name).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }
        //поиск книги по названию
        public ICollection<Storage.Entity.Book> GetBook(string name)
        {
            return context.Book.Where(bk => bk.Name == name).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }
        //поиск по жанру
        public ICollection<Storage.Entity.Book> GetGenre(int id)
        {
            return context.Book.Where(bk => bk.Id == id).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }
        //сортировка по возрастанию
        public ICollection<Storage.Entity.Book> DownRating()
        {
            return context.Book.OrderBy(r => r.Rating.WorldRating).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }
        //сортировка по убыванию
        public ICollection<Storage.Entity.Book> UpRating()
        {
            return context.Book.OrderByDescending(r => r.Rating.WorldRating).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }
        //взятие промежутка
        public ICollection<Storage.Entity.Book> PridelRating(double rait1, double rait2)
        {
            return context.Book.Where(r => r.Rating.WorldRating >= rait1).Where(r => r.Rating.WorldRating <= rait2).Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }
    }


}
