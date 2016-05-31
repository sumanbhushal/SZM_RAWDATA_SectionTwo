using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SearchModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public double Rank { get; set; }
    }
}