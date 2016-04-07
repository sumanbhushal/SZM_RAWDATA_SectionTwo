﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PostType")]
        public int PostTypeId { get; set; }

        public int? ParentId { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Title { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public int? Mark { get; set; }

        public PostType PostType { get; set; }
        public User User { get; set; }
    }
}
