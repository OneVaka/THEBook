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

        /*public BookManeger()
         {
             context = new Exampl();
         }
        */

        public BookManeger(BookContext context)
        {
            this.context = context;
        }

        public ICollection<Storage.Entity.Book> GetAll()
        {
            return context.Book.Include(st1 => st1.Author).Include(st2 => st2.Rating).Include(st3 => st3.Genre).ToList();
        }

        public ICollection<Storage.Entity.Book> GetAutor()
        {
            throw new NotImplementedException();
        }

        public ICollection<Storage.Entity.Book> GetBook(int id)
        {
            return context.Book.Where(bk => bk.Id == id).ToList();
        }

        public ICollection<Storage.Entity.Book> GetGenre()
        {
            throw new NotImplementedException();
        }
    }
}
