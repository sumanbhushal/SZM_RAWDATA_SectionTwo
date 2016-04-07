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
    public class UsersController : ApiController
    {
        IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var limit = pagesize;
            var offset = page * pagesize;
            var userData = _repository.GetAllUserData(limit, offset).Select(u => ModelFactory.Map(u, Url));

            var totalNumberOfUser = _repository.GetNumberOfUser();

            var lastPage = totalNumberOfUser / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.UsersRoute, new { page = page - 1, pagesize });
            var next = page >= lastPage ? null : Url.Link(Config.UsersRoute, new { page = page + 1, pagesize });

            var result = new
            {
                TotalUser = totalNumberOfUser,
                Prev = prev,
                Next = next,
                Data = userData

            };

            return Ok(result);
        }
    }
}
