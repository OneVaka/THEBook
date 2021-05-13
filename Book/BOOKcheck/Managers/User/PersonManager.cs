using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BOOKcheck.Storage;
using BOOKcheck.Storage.Lib;
using BOOKcheck.Storage.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BOOKcheck.Managers.User
{
    public class PersonManager : IPersonManager
    {
        private UniversalContext context;

        public PersonManager(UniversalContext context)
        {
            this.context = context;
        }

        public async Task<string> GetPass(int IdUser)
        {
            var user = await context.Person.FirstOrDefaultAsync(u => u.Id == IdUser);

            
            return user.Pass;
        }

        public async Task<string> GetLogin(int IdUser)
        {
            var user = await context.Person.FirstOrDefaultAsync(u => u.Id == IdUser);
            
            return user.Login;
        }

        public async Task<string> GetMail(int IdUser)
        {
            var user = await context.Person.FirstOrDefaultAsync(u => u.Id == IdUser);
            return user.Mail;
        }

        //получить Id билиотеки с которой связан пользователь 
        public async Task<int> GetIdLiber(string Login)
        {
            var user = await context.Person.FirstOrDefaultAsync(u => u.Login == Login);

            return user.IdUserLiber;
        }





        //создание библиотеки 
        public async Task<int> AddLiber()
        {
            UserLiber liber = new UserLiber();
           
           await context.UserLiber.AddAsync(liber);
           await context.SaveChangesAsync();

            return liber.Id;
        }



        //проверка на совпадение печеньки
        public async Task<bool> CheckCookie(string userCookie, string Login)
        {
            Person user = await context.Person.FirstOrDefaultAsync(st => st.Cookies == userCookie && st.Login == Login);

            if (user != null)

                return true;

            else
                return false;

        }

        //создание печеньки для пользователя
        public string GetCookie(string Login)
        {

            //byte[] hashLogin = Encoding.Default.GetBytes(Login);

            byte[] Hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(Login));
            string hashString = BitConverter.ToString(Hash).ToLower().Replace("-", "");


            return hashString+Login;
        }

        //вход зарегистрированного пользователя
        public async Task<bool> LogInUser(string Login, string Pass, ControllerContext controllerContext)
        {
            Person user;

            user = await context.Person.FirstOrDefaultAsync(st => (st.Login == Login && st.Pass == Pass));

            if (user != null)
            {

                controllerContext.HttpContext.Response.Cookies.Append("bookCookie", user.Cookies);

                controllerContext.HttpContext.Response.Cookies.Append("Login", user.Login);

                return true;
            }

            return false;
        }

        //создать/зарегистрировать пользователя
        public async Task<bool> AddUser(string Mail, string Pass, string Login, ControllerContext controllerContext)
        {
            Person user;
            user = await context.Person.FirstOrDefaultAsync(st => st.Mail == Mail || st.Login == Login);

            //данная почта или логин уже заняты
            if (user != null)
                return false;
            

            user = new Person();

            user.Mail  = Mail;
            user.Login = Login;
            user.Pass  = Pass;
            user.IdUserLiber = await AddLiber();
            user.Cookies = GetCookie(Login);

            await context.Person.AddAsync(user);
            await context.SaveChangesAsync();


            controllerContext.HttpContext.Response.Cookies.Append("bookCookie", user.Cookies);

            controllerContext.HttpContext.Response.Cookies.Append("Login", user.Login);


            return true;
        }


    }
}
