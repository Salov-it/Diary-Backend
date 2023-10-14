

namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        void CreateTableUser();
        void UserAdd(string Login,string Password,int Phone,DateTime Create,DateTime Update);
        void UserUpdate();
        void DeleteTableUser();
    }
}
