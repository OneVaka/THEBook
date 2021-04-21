using System;
using BOOKcheck.Storage.Entity;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BOOKcheck.Storage.Lib
{
    public class Page
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Number { get; set; }
    }
}
