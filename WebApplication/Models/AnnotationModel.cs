using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AnnotationModel
    {
        public string Url { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string AnnotationDescription { get; set; }
        public DateTime AnnotationCreateDate { get; set; }
    }
}