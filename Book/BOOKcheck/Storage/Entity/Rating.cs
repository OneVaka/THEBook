using System;
using SQLite;

namespace BOOKcheck.Storage.Entity
{
    public class Rating
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        
        public decimal OurRating { get; set; }

        
        public decimal WorldRating { get; set; }
    }
}
