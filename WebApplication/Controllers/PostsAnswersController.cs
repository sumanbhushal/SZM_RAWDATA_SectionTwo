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
    public class PostsAnswersController : ApiController
    {
        IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int postId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var listOfComment = _repository.GetAnswersByPostId(postId, limit, offset).Select(c => ModelFactory.Map(c, Url));
            var totalComment = _repository.GetNumberOfAnswerByPostId(postId);

            var lastPage = totalComment / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.PostsCommentsRoute, new { page = page - 1, pagesize });
            var next = page >= lastPage ? null : Url.Link(Config.PostsCommentsRoute, new { page = page + 1, pagesize });

            var result = new
            {
                Total = totalComment,
                Prev = prev,
                Next = next,
                Data = listOfComment
            };

            return Ok(result);
        }
    }
}
