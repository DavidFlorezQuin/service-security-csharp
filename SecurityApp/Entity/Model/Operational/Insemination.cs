﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Insemination : ABaseModel
    {
        public DateTime date { get; set; }
        public string observation { get; set; }

    }
}