using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BOOKcheck.Storage;
using BOOKcheck.Storage.Lib;
using BOOKcheck.Storage.User;
using Microsoft.AspNetCore.Mvc;

namespace BOOKcheck.Managers.User
{
    public class PersonManager : IPersonManager
    {
        private UniversalContext context;

        public PersonManager(UniversalContext context)
        {
            this.context = context;
        }

        public string GetPass(int IdUser)
        {
            return context.Person.FirstOrDefault(u => u.Id == IdUser).Pass;
        }

        public string GetLogin(int IdUser)
        {
            return context.Person.FirstOrDefault(u => u.Id == IdUser).Login;
        }

        public string GetMail(int IdUser)
        {
            return context.Person.FirstOrDefault(u => u.Id == IdUser).Mail;
        }

        //получить Id билиотеки с которой связан пользователь 
        public int GetIdLiber(string Login)
        {
            return context.Person.FirstOrDefault(u => u.Login == Login).IdUserLiber;
        }

        //создание библиотеки 
        public int AddLiber()
        {
            UserLiber liber = new UserLiber();
           
            context.UserLiber.Add(liber);
            context.SaveChanges();

            return liber.Id;
        }






        //проверка на совпадение печеньки
        public bool CheckCookie(string userCookie)
        {
            Person user = context.Person.FirstOrDefault(st => st.Cookies == userCookie);

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
        public bool LogInUser(string Login, string Pass, ControllerContext controllerContext)
        {
            Person user;

            user = context.Person.FirstOrDefault(st => (st.Login == Login && st.Pass == Pass));

            if (user != null)
            {

                controllerContext.HttpContext.Response.Cookies.Append("bookCookie", user.Cookies);

                controllerContext.HttpContext.Response.Cookies.Append("Login", user.Login);

                return true;
            }

            return false;
        }

        //создать/зарегистрировать пользователя
        public bool AddUser(string Mail, string Pass, string Login, ControllerContext controllerContext)
        {
            Person user;
            user = context.Person.FirstOrDefault(st => st.Mail == Mail || st.Login == Login);

            //данная почта или логин уже заняты
            if (user != null)
                return false;
            

            user = new Person();

            user.Mail  = Mail;
            user.Login = Login;
            user.Pass  = Pass;
            user.IdUserLiber = AddLiber();
            user.Cookies = GetCookie(Login);

            context.Person.Add(user);
            context.SaveChanges();


            controllerContext.HttpContext.Response.Cookies.Append("bookCookie", user.Cookies);

            controllerContext.HttpContext.Response.Cookies.Append("Login", user.Login);


            return true;
        }


    }
}
