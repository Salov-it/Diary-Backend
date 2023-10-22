using UserServices.Domain;

namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        Task<string> CreateTableUser();
        Task<string> UserAdd(string Login,string Password,string Phone,DateTime Create);
        Task<string> UserUpdate(string Login,string Phone);
        Task<string> GetByUserId(string Login);
        
    }
}
