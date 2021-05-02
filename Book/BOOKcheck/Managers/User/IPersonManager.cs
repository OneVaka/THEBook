using System;


namespace BOOKcheck.Managers.User
{
    public interface IPersonManager
    {
        public void AddUser();

        public int AddLiber();

        public int GetIdLiber(int IdUser);
    }
}
