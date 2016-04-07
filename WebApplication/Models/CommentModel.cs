using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CommentModel
    {
        public string Url { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }     
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? Mark { get; set; }

    }
}