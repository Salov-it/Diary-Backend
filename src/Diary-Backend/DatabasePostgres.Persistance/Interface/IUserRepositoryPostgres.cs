

namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        void CreateTableUser();
        void UserAdd();
        void UserUpdate();
        void DeleteTableUser();
    }
}
