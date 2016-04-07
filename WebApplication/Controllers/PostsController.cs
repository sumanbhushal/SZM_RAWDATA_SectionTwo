using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using DomainModel;
using MySqlDatabase;
using WebApplication.Models;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    public class PostsController : ApiController
    {
        IRepository _repository = new MySqlRepository();
        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var listOfPost = _repository.GetPosts(limit, offset).Select(p => ModelFactory.Map(p, Url));
            var totalPost = _repository.GetNumberOfPosts();
            var lastpage = totalPost / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.PostsRoute, new { page = page - 1, pagesize });
            var next = page >= lastpage ? null : Url.Link(Config.PostsRoute, new { page = page + 1, pagesize });

            var result = new
            {
                Total = totalPost,
                Prev = prev,
                Next = next,
                Data = listOfPost
            };

            return Ok(result);
        }

        public IHttpActionResult Get(string keyword)
        {
            var searchResults = _repository.GetAllMatchPostsWithKeyword(keyword);


            return Ok(searchResults);
        }

        public IHttpActionResult Put(int id, PostModel model)
        {
            var post = new Post
            {
                Id = id,
                Title = model.Title
            };

            /*if(_repository.UpdatePost(id, post) == false)
                return NotFound():
            return Created(Config.PostsRoute, ModelFactory.Map(post));*/
            return Ok();
        }

    }
}
