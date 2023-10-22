
namespace UserServices.Application.Interface
{
    public interface IUserAuthorization
    {
        Task<string> Authorization();
    }
}
