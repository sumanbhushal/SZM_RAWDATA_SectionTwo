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
    public class PostsController : ApiController
    {
        IRepository postRepository = new MySqlRepository();

        public IHttpActionResult Get()
        {
            return Ok("This is just test!!!");
        }

    }
}
