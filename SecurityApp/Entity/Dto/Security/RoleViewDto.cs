using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class RoleViewDto
    {
        public int Id { get; set; }

        public int IdRole { get; set; }

        public int IdView { get; set; }
        public string NameRole { get; set; }
        public string NameView { get; set; }
    }
}
