using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UserServices.Application.Config
{
    public class JwtSettings
    {
        public const string Key = "Salov_syka_jwt_jdhdhsugsgdfuidhf_generalishin";

        public const string Issuer = "salovit.ru";

        public const string Audience = "salovit.ru";
        public int DurationInMinutes = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
