﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class HealthHistory
    {
        public string diagnosis { get; set; }
        public string medicines { get; set; }
        public int treatment_days { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public int AnimalId { get; set; }

    }
}
