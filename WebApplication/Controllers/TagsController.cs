using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using MySqlDatabase;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    public class TagsController : ApiController
    {
        IRepository _repository = new MySqlRepository();
        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var limit = pagesize;
            var offset = page * pagesize;

            var tagsData = _repository.GetTags(limit, offset);

            var totalNumberOfTagsData = _repository.GetNumberOfTags();

            var lastPage = totalNumberOfTagsData / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.TagsRoute, new { page = page - 1, pagesize });
            var next = page >= lastPage ? null : Url.Link(Config.TagsRoute, new { page = page + 1, pagesize });

            var result = new
            {
                TotalTags = totalNumberOfTagsData,
                Prev = prev,
                Next = next,
                TagsData = tagsData

            };
            return Ok(result);
        }
    }
}
