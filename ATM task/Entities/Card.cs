﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_task.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}
