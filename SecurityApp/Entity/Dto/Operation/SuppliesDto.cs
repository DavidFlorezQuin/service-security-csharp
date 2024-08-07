using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class SuppliesDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public string input_type { get; set; }
        public DateTime date { get; set; }
    }
}
