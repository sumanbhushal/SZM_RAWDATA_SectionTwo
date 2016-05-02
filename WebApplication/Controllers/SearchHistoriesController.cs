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

        public IHttpActionResult Get(int id)
        {
            var searchHistoryById = _repository.FindSearchHistoryById(id).Select(sh => ModelFactory.Map(sh, Url));
            return Ok(searchHistoryById);
        }

        public IHttpActionResult Put(SearchHistoryModel searchHistoryModel)
        {
            var searchHisotry = new SearchHistory
            {
                Keyword = searchHistoryModel.Keyword,
                SearchDateTime = DateTime.Now
            };
            if (_repository.InsertNewSearchHistory(searchHisotry) == false)
                return NotFound();
            return Created(Config.SearchHistoriesRoute, ModelFactory.Map(searchHisotry, Url));

            //return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var data = _repository.FindSearchHistoryById(id);
            if (data != null)
            {
                if (_repository.DeleteSearchHistoryById(id))
                {
                    return Ok();
                }
                return NotFound();
            }
            return NotFound();
        }

        public IHttpActionResult Delete()
        {
            if (_repository.DeleteAllSearchHistories() == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
