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
        private readonly IRepository _repository;

        public AnnotationsController(IRepository repository)
        {
           _repository = repository;
        }
        
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
            var data = _repository.FindAnnotationById(id).Select(a => ModelFactory.Map(a, Url));
            if (data == null) return NotFound();
            return Ok(data);
        }
        
        /*Insert Annotation*/
        public IHttpActionResult Post(AnnotationModel annotationModel)
        {
            var annotation = new Annotation
            {
                PostId = annotationModel.PostId,
                CommentId = annotationModel.CommentId,
                AnnotationCreateDate = annotationModel.AnnotationCreateDate,
                AnnotationDescription = annotationModel.AnnotationDescription
            };
            _repository.InsertNewAnnotation(annotation);
            return Created(Config.AnnotationRoute, ModelFactory.Map(annotation, Url));
            //return Ok();
        }

        /*Update Annotation*/

        public IHttpActionResult Put(int id, AnnotationModel annotationModel)
        {
            var annotation = new Annotation
            {
                Id = id,
                PostId = annotationModel.PostId,
                CommentId = annotationModel.CommentId,
                AnnotationCreateDate = annotationModel.AnnotationCreateDate,
                AnnotationDescription = annotationModel.AnnotationDescription
            };

            if (!_repository.UpdateAnnotation(annotation))
            {
                return NotFound();
            }
            return Ok();

        }

        /*Delete Annotation*/
        public IHttpActionResult Delete(int id)
        {
            if (!_repository.DeleteAnnotationById(id)) return NotFound();
            return Ok();
        }


    }
}
