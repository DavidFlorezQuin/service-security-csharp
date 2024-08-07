using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Lot : ABaseModel
    {
        public string name { get; set; }
        public string production_system { get; set; }

        public int LottId { get; set; }
        public Lot Lott { get; set; }


    }
}
