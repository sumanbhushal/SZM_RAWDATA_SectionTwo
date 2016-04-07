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
    public class AnnotationsController : ApiController
    {
        private IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var annotationData = _repository.GetAnnotions(limit, offset).Select(a => ModelFactory.Map(a, Url));

            var totalNumberOfAnnotation = _repository.GetNumberOfAllAnnotation();

            var lastPage = totalNumberOfAnnotation / pagesize;

            var prev = page <= 0 ? null : Url.Link(Config.AnnotationRoute, new { page = page - 1, pagesize });
            var next = page >= lastPage ? null : Url.Link(Config.AnnotationRoute, new { page = page + 1, pagesize });

            var reslult = new
            {
                TotalAnnotationData = totalNumberOfAnnotation,
                Prev = prev,
                Next = next,
                Data = annotationData
            };
            return Ok(reslult);
        }

        public IHttpActionResult Get(int id)
        {
            var data = _repository.FindAnnotationById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        public IHttpActionResult Post(int id, AnnotationModel annotationModel)
        {
            var annotation = new Annotation
            {
                Id = id,
                PostId = annotationModel.PostId,
                CommentId = annotationModel.CommentId,
                AnnotationCreateDate = annotationModel.AnnotationCreateDate,
                AnnotationDescription = annotationModel.AnnotationDescription
            };

            if (_repository.InsertNewAnnotation(annotation) == false)
                return NotFound();
            return Created(Config.AnnotationRoute, ModelFactory.Map(annotation, Url));
            //return Ok();
        }

    }
}
