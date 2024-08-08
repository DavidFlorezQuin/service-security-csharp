using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public int PersonId { get; set; }
    }

}
