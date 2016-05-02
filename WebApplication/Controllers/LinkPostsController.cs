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
    public class LinkPostsController : ApiController
    {
        IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var listOfLinkToPost = _repository.GetLinkToPost(limit, offset).Select(p => ModelFactory.Map(p, Url));

            var totalLinkPosts = _repository.GetNumberOfLinkPosts();

            var lastpage = totalLinkPosts / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.LinkPostsRoute, new { page = page - 1, pagesize });
            var next = page >= lastpage ? null : Url.Link(Config.LinkPostsRoute, new { page = page + 1, pagesize });
            var result = new
            {
                Total = totalLinkPosts,
                Prev = prev,
                Next = next,
                Data = listOfLinkToPost
            };

            return Ok(result);
        }

        public IHttpActionResult Get(int postId)
        {
            var linkToPostByPostId = _repository.FindLinkToPostByPostId(postId).Select(lp => ModelFactory.Map(lp, Url));
            return Ok(linkToPostByPostId);
        }
    }
}
