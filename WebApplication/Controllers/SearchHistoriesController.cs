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
    public class SearchHistoriesController : ApiController
    {
        IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var searhHistoryData = _repository.GetAllSearchHistory(limit, offset).Select(sh => ModelFactory.Map(sh, Url));

            var totalNumberOfSearchHistory = _repository.GetNumberofSearchHistory();
            var lastPage = totalNumberOfSearchHistory / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.SearchHistoriesRoute, new { page = page - 1, pagesize });
            var next = page >= lastPage ? null : Url.Link(Config.SearchHistoriesRoute, new { page = page + 1, pagesize });

            var result = new
            {
                TotalNumberOfSearhHisoty = totalNumberOfSearchHistory,
                Prev = prev,
                Next = next,
                Data = searhHistoryData
            };
            return Ok(result);
        }
    }
}
