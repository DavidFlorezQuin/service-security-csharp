using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Dto.Localitation
{
    public class CityDto : ABaseModel
    {
        public int Id { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }
        public int CountryId { get; set; }

    }
}
