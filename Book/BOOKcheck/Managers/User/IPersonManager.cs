using Microsoft.AspNetCore.Mvc;
using System;


namespace BOOKcheck.Managers.User
{
    public interface IPersonManager
    {
        public int GetIdLiber(string Login);

        public bool CheckCookie(string userCookie);

        public bool LogInUser(string Login, string Pass, ControllerContext controllerContext);

        public bool AddUser(string Mail,string Pass, string Login, ControllerContext controllerContext);

    }
}
