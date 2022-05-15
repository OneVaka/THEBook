using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BOOKcheck.Managers.User
{
    public interface IPersonManager
    {
        Task<int> GetIdLiber(string Login);

        Task<bool> CheckCookie(string userCookie, string Login);

        Task<bool> LogInUser(string Login, string Pass, ControllerContext controllerContext);

        Task<bool> AddUser(string Mail,string Pass, string Login, ControllerContext controllerContext);

    }
}
