using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PostModel
    {
        public string Url { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int? Mark { get; set; }
    }
}