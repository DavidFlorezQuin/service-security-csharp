using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InventoryDto
    {
        public DateTime admission_date { get; set; }
        public int stock { get; set; }
        public int SuppliesId { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
