using UserServices.Application.Interface;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class UserAuthorization : IUserAuthorization
    {
        public Task<string> Authorization()
        {
            throw new NotImplementedException();
        }
    }
}
