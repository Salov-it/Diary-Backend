﻿
namespace UserServices.Domain
{
   public class User
    {
       public int id { get; set; }
       public string Login { get; set; }
       public string Password { get; set; }
       public string Phone { get; set; }
       public DateTime Created { get; set; }
    }
}
