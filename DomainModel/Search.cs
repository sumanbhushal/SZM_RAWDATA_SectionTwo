﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Search
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public double Rank { get; set; }
    }
}
