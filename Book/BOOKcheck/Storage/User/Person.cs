using System;
using System.Collections.Generic;
using BOOKcheck.Storage.Lib;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BOOKcheck.Storage.User
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(UserLiber))]
        public int IdUserLiber { get; set; }
        [OneToOne]
        public UserLiber UserLiber { get; set; }

    }
}
