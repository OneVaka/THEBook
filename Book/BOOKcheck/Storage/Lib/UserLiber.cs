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

        [OneToMany]
        public List<EndRead> EndRead { get; set; }

        [OneToMany]
        public List<FinishRead> FinishRead { get; set; }

        [OneToMany]
        public List<NowRead> NowRead { get; set; }

        [OneToMany]
        public List<WantRead> WantRead { get; set; }

    }
}
