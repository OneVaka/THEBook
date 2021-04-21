using System;
using BOOKcheck.Storage.Entity;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BOOKcheck.Storage.Lib
{
    public class FinishRead
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Book))]
        public int IdBook { get; set; }
        [OneToOne]
        public Book Book { get; set; }

        [ForeignKey(typeof(Page))]
        public int IdPage { get; set; }
        [OneToOne]
        public Page Page { get; set; }

        [ForeignKey(typeof(UserLiber))]
        public int IdUserLiber { get; set; }
    }
}
