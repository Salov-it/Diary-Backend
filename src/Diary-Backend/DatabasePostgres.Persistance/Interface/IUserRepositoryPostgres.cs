using UserServices.Domain;

namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        Task<string> CreateTableUser();
        Task<string> UserAdd(string Login,string Password,int Phone,DateTime Create);
        void UserUpdate();
        void DeleteTableUser();
        Task<List<User>> GetAll();
    }
}
