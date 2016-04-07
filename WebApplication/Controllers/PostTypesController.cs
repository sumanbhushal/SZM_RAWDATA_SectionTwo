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
        IRepository postTypeRepository = new MySqlRepository();

        public IHttpActionResult Get()
        {
            var postTypeDate = postTypeRepository.GetPostType();
            return Ok(postTypeDate);
        }
    }
}
