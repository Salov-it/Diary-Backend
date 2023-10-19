using UserServices.Domain;

namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        Task<string> CreateTableUser();
        Task<string> UserAdd(string Login,string Password,string Phone,DateTime Create);
        void UserUpdate();
        void DeleteTableUser();
        Task<List<User>> GetAll();
    }
}
