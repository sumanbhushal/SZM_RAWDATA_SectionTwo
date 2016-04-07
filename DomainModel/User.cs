using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime creationDate { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }
    }
}
