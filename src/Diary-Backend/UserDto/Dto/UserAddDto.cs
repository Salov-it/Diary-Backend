using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDto.Dto
{
    public class UserAddDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }
    }
}
