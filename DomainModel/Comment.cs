using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public int? Mark { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
