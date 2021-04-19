using System;
using SQLite;

namespace BOOKcheck.Storage.Entity
{
    public class Genre
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        
        [MaxLength(50)]
        public string Name { get; set; }

      
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
