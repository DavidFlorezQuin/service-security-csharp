using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class View : ABaseModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string route{ get; set; }
        public int ModuleId { get; set; }
        public Modulo Module { get; set; }

        public ICollection<RoleView> RoleView { get; set; }


    }
}
