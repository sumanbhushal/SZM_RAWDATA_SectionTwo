﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class PostType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
