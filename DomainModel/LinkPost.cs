using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class LinkPost
    {
        [ForeignKey("Post")]
        public int  PostId { get; set; }

        [ForeignKey("Post")]
        public int LinkPostId { get; set; }

        public Post Post { get; set; }
    }
}
