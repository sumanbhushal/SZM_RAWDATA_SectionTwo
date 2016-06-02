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
    public class PostsTagsController : ApiController
    {
        IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int postId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var listOfTags = _repository.GetTagsByPostId(postId, limit, offset).Select(c => ModelFactory.Map(c, Url));
            var totalTags = _repository.GetNumberOfTagsByPostId(postId);

            var lastPage = totalTags / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.PostsTagsRoute, new { page = page - 1, pagesize });
            var next = page >= lastPage ? null : Url.Link(Config.PostsTagsRoute, new { page = page + 1, pagesize });

            var result = new
            {
                Total = totalTags,
                Prev = prev,
                Next = next,
                Data = listOfTags
            };

            return Ok(result);
        }
    }
}
