using BOOKcheck.Storage.Entity;
using BOOKcheck.Storage.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKcheck.Models
{
    public class UserLibModel
    {
        public Book Book { get; set; }
        
        public Page Page { get; set; }

    }   
}
