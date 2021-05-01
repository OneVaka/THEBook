using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BOOKcheck.Storage.Lib
{
    public class UserLiber
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //1
        [OneToMany]
        public List<EndRead> EndRead { get; set; } = new List<EndRead>();

        //2
        [OneToMany]
        public List<FinishRead> FinishRead { get; set; } = new List<FinishRead>();

        //3
        [OneToMany]
        public List<NowRead> NowRead { get; set; } = new List<NowRead>();

        //4
        [OneToMany]
        public List<WantRead> WantRead { get; set; } = new List<WantRead>();

    }
}
