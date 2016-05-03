using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using DataAccessLayer;
using DomainModel;
using Moq;
using NUnit.Framework;
using WebApplication.Controllers;
using WebApplication.Models;

namespace WebApp.Tests.WebApplication.Controllers
{
    class AnnotationsControllerTests
    {
        public Mock<IRepository> RepositoryMock;
        public Mock<UrlHelper> UrlHelperMock;

        [SetUp]
        public void SetUp()
        {
            RepositoryMock = new Mock<IRepository>();
            UrlHelperMock = new Mock<UrlHelper>();
        }

        [Test]
        public void Get_Annotation_WithoutArguments_ReturnOK()
        {
            
            var annotationController = new AnnotationsController(RepositoryMock.Object);
           // annotationController.Url = UrlHelperMock.Object;

            var response = annotationController.Get() as OkNegotiatedContentResult<IEnumerable<Annotation>>;

            Assert.NotNull(response);
        }

        
    }
}
