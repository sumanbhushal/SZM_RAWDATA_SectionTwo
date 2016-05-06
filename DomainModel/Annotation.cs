using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Annotation
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int? CommentId { get; set; }
        public string AnnotationDescription { get; set; }
        public DateTime AnnotationCreateDate { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }
    }
}
