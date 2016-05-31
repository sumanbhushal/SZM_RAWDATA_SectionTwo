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
    public class SearchController : ApiController
    {
        IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(string keyword, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var keywordForDb = keyword.Replace(" ", ",");
            int limit = pagesize;
            int offset = page * pagesize;
            var searchResult =
                _repository.GetAllPostsWithSearchKeyword(keywordForDb, limit, offset)
                    .Select(s => ModelFactory.Map(s, Url));

            var totalSearchResult = _repository.GetNumberOfSearchPosts(keywordForDb);
            var lastpage = totalSearchResult / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.SearchPostsRoute, new { keyword, page = page - 1, pagesize });
            var next = page >= lastpage ? null : Url.Link(Config.SearchPostsRoute, new { keyword, page = page + 1, pagesize });

            var result = new
            {
                Total = totalSearchResult,
                Prev = prev,
                Next = next,
                Data = searchResult
            };

            return Ok(result);
        }
    }
}
