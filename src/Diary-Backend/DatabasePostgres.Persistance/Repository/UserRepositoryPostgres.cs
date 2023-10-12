using DatabasePostgres.Persistance.Config;
using DatabasePostgres.Persistance.Interface;

namespace DatabasePostgres.Persistance.Repository
{
    public class UserRepositoryPostgres : IUserRepositoryPostgres
    {
        private readonly string _Connect;
        Configs configs = new Configs();

       public UserRepositoryPostgres()
        {
            _Connect = configs.Connection;
        }
        public void CreateTableUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteTableUser()
        {
            throw new NotImplementedException();
        }

        public void UserAdd()
        {
            throw new NotImplementedException();
        }

        public void UserUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
