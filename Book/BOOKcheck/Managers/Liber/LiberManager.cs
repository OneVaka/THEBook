using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOOKcheck.Storage;

namespace BOOKcheck.Managers.Liber
{
    public class LiberManager
    {   //возможно надо поменять на контект liber
        private BookContext context;

        public LiberManager(BookContext context)
        {
            this.context = context;
        }

       
    }
}
