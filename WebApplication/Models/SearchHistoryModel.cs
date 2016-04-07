using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SearchHistoryModel
    {
        public string Url { get; set; }
        public string Keyword { get; set; }
        public DateTime SearchDateTime { get; set; }
    }
}