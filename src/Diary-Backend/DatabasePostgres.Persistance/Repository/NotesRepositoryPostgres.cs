using DatabasePostgres.Persistance.Config;

namespace DatabasePostgres.Persistance.Repository
{
    public class NotesRepositoryPostgres
    {
        private readonly string _Connect;
        Configs configs = new Configs();

       public NotesRepositoryPostgres()
        {
            _Connect = configs.Connection;
        }
    }
}
