using System;
using System.Linq;
using BOOKcheck.Storage;
using BOOKcheck.Storage.Lib;
using BOOKcheck.Storage.User;

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

        //создание библиотеки 
        public int AddLiber()
        {
            UserLiber liber = new UserLiber();

            context.UserLiber.Add(liber);
            context.SaveChanges();

            return liber.Id;
        }

        //создать пользователя
        public void AddUser()
        {
            Person user = new Person();

            user.IdUserLiber = AddLiber();
            user.Mail = GetMail(user.Id);
            user.Login = GetLogin(user.Id);
            user.Pass = GetPass(user.Id);

            context.Person.Add(user);
            context.SaveChanges();
        }

        //получить Id билиотеки с которой связан пользователь 
        public int GetIdLiber(int IdUser)
        {
            return context.Person.FirstOrDefault(u => u.Id == IdUser).IdUserLiber;
        }
    }
}
