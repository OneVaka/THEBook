using System;
using SQLite;

namespace BOOKcheck.Storage.Entity
{
    public class Rating
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        
        public double OurRating { get; set; }

        
        public double WorldRating { get; set; }
    }
}
