using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class UserRoleDto
    {

        public int Id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }
        public string NameUser { get; set; }
        public string NameRole { get; set; }

    }
}
