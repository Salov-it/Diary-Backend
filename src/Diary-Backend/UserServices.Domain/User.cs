
namespace UserServices.Domain
{
   public class User
    {
       public int id { get; set; }
       public string Login { get; set; }
       public string Password { get; set; }
       public int Phone { get; set; }
       public DateTime Create { get; set; }
       public DateTime Update { get; set; }
    }
}
