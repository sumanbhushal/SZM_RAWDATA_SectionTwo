using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Tag
    {
        [Key]
        [Column(Order = 0)]
        public int PostId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Tagtype { get; set; }
    }
}
