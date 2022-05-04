﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ratio:IEntity
    {
        public int Id { get; set; }
        public decimal CommissionRatio { get; set; }
        public bool IsActive { get; set; }
    }
}
