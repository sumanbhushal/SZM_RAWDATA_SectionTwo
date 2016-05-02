using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using MySqlDatabase;

namespace WebApplication.Controllers
{
    public class PostTypesController : ApiController
    {
        IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get()
        {
            var postTypeDate = _repository.GetPostType().Select(pt => ModelFactory.Map(pt, Url));
            return Ok(postTypeDate);
        }

        public IHttpActionResult Get(int id)
        {
            var postTypeDataById = _repository.FindPostTypeById(id).Select(pt => ModelFactory.Map(pt, Url));
            if (postTypeDataById == null) return NotFound();
            return Ok(postTypeDataById);
        }
    }
}
