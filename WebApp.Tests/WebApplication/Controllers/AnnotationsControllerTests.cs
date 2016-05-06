using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using DataAccessLayer;
using Moq;
using NUnit.Framework;
using DomainModel;
using WebApplication;
using WebApplication.Controllers;
using WebApplication.Models;

namespace WebApp.Tests.WebApplication.Controllers
{
    public class AnnotationControllerTests
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
        public void Get_WihtInvalidLimitAndOffset_CallToGetAnnotations()
        {
            //Arrange
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);

            //Act
            AnnotationController.Get(-1, -5);

            //Assert
            RepositoryMock.Verify(rm => rm.GetAnnotions(It.Is<int>(l => l == -1), It.Is<int>(o => o == -5)), Times.Once);
        }

        [Test]
        public void Get_WithValidLimitAndOffset_CallGetAnnotations()
        {
            //Arrange

            var AnnotationController = new AnnotationsController(RepositoryMock.Object);


            //Act
            AnnotationController.Get(1, 5);

            //Assert
            RepositoryMock.Verify(rm => rm.GetAnnotions(It.Is<int>(L => L == 1), It.Is<int>(o => o == 5)), Times.Once);

        }

        [Test]
        public void Get_WihtValidId_ReturnOkWithAnnotationModel()
        {
            //Arrange
            var data = new List<Annotation>
            {
                new Annotation
                {
                    PostId = 19,
                    CommentId = 49,
                    AnnotationDescription = "Testing",
                    AnnotationCreateDate = new DateTime(2015, 6, 6)
                }
            };
            RepositoryMock.Setup(rm => rm.FindAnnotationById(It.IsAny<int>()))
                .Returns(data);
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);
            AnnotationController.Url = UrlHelperMock.Object;

            //Act
            var response = AnnotationController.Get(1) as OkNegotiatedContentResult<AnnotationModel>;

            //Assert
            Assert.NotNull(response);
        }

        [Test]
        public void Get_WihtValidId_CallToFindAnnotationById()
        {
            //Arrange
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);

            //Act
            AnnotationController.Get(1);

            //Assert
            RepositoryMock.Verify(rm => rm.FindAnnotationById(It.Is<int>(id => id == 1)), Times.Once);
        }

        [Test]
        public void Get_WihtInvalidId_ReturnNotFound()
        {
            //Arrange
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);

            //Act
            var response = AnnotationController.Get(-1) as NotFoundResult;

            //Assert
            Assert.NotNull(response);
        }

        [Test]
        public void Get_WihtInvalidId_CallToFindAnnotationById()
        {
            //Arrange
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);

            //Act
            AnnotationController.Get(-1);

            //Assert
            RepositoryMock.Verify(rm => rm.FindAnnotationById(It.Is<int>(id => id == -1)), Times.Once);
        }

        [Test]
        public void Post_WithAnnotationModel_ReturnCreatedWithAnnotationRoute()
        {
            //Arrange
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);
            AnnotationController.Url = UrlHelperMock.Object;
            var AnnotationModel = new AnnotationModel
            {
                PostId = 19,
                CommentId = 49,
                AnnotationDescription = "Testing",
                AnnotationCreateDate = new DateTime(2015, 6, 6)
            };

            //Act
            var response = AnnotationController.Post(AnnotationModel) as CreatedNegotiatedContentResult<AnnotationModel>;

            //Assert
            Assert.NotNull(response);
            Assert.AreEqual("AnnotationsApi", response.Location.ToString());
        }

        [Test]
        public void Post_WithAnnotationModel_CallInsert()
        {
            //Arrange
            RepositoryMock.Setup(rm => rm.InsertNewAnnotation(It.IsAny<Annotation>()))
                .Callback<Annotation>(a => a.Id = 1);

            var AnnotationController = new AnnotationsController(RepositoryMock.Object)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/annotations") }
            };
            WebApiConfig.Register(AnnotationController.Configuration);

            var AnnotationModel = new AnnotationModel
            {
                PostId = 19,
                CommentId = 49,
                AnnotationDescription = "Testing",
                AnnotationCreateDate = new DateTime(2015, 6, 6)
            };

            //Act
            var response = AnnotationController.Post(AnnotationModel) as CreatedNegotiatedContentResult<AnnotationModel>;
            //Assert
            Assert.AreEqual("http://localhost/api/annotations/1", response.Content.Url);
            RepositoryMock.Verify(rm => rm.InsertNewAnnotation(It.Is<Annotation>(
                a => a.PostId == 19
                && a.CommentId == 49
                && a.AnnotationDescription == "Testing"
                && a.AnnotationCreateDate == new DateTime(2015, 6, 6)
                && a.Id == 1)));
        }

        [Test]
        public void Put_WithValidIdMandAnnotationModel_ReturnOK()
        {
            //Arrange
            RepositoryMock.Setup(rm => rm.UpdateAnnotation(It.IsAny<Annotation>()))
               .Returns(true);
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);
            var AnnotationModel = new AnnotationModel
            {
                PostId = 19,
                CommentId = 49,
                AnnotationDescription = "Testing",
                AnnotationCreateDate = new DateTime(2015, 6, 6)
            };

            //Act
            var response = AnnotationController.Put(1, AnnotationModel) as OkResult;

            //Assert
            Assert.NotNull(response);
        }

        [Test]
        public void Put_WithValidIdMandAnnotationModel_CallServiceUpdate()
        {
            //Arrange
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);
            var AnnotationModel = new AnnotationModel
            {
                PostId = 19,
                CommentId = 49,
                AnnotationDescription = "Testing",
                AnnotationCreateDate = new DateTime(2015, 6, 6)
            };

            //Act
            AnnotationController.Put(1, AnnotationModel);

            //Assert
            RepositoryMock.Verify(rm => rm.UpdateAnnotation(It.Is<Annotation>(a => a.Id == 1)));
        }

        [Test]
        public void Put_WithInvalidId_ReturnNotFound()
        {
            //Arrange
            RepositoryMock.Setup(rm => rm.DeleteAnnotationById(It.IsAny<int>()))
               .Returns(false);
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);
            var AnnotationModel = new AnnotationModel
            {
                PostId = 19,
                CommentId = 49,
                AnnotationDescription = "Testing",
                AnnotationCreateDate = new DateTime(2015, 6, 6)
            };

            //Act
            var response = AnnotationController.Put(-1, AnnotationModel) as NotFoundResult;

            //Assert
            Assert.NotNull(response);
        }

        [Test]
        public void Delet_WithValidId_ReturnOK()
        {
            //Arrange
            RepositoryMock.Setup(rm => rm.DeleteAnnotationById(It.IsAny<int>()))
                .Returns(true);
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);

            //Act
            var response = AnnotationController.Delete(1) as OkResult;

            //Assert
            Assert.NotNull(response);
        }

        [Test]
        public void Delet_WithValidId_CallServiceDelete()
        {
            //Arrange
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);

            //Act
            AnnotationController.Delete(1);

            //Assert
            RepositoryMock.Verify(rm => rm.DeleteAnnotationById(It.Is<int>(id => id == 1)));

        }

        [Test]
        public void Delet_WithInvalidId_ReturnNotFound()
        {
            //Arrange
            RepositoryMock.Setup(rm => rm.DeleteAnnotationById(It.IsAny<int>()))
                .Returns(false);
            var AnnotationController = new AnnotationsController(RepositoryMock.Object);

            //Act
            var response = AnnotationController.Delete(-1) as NotFoundResult;

            //Assert
            Assert.NotNull(response);
            RepositoryMock.Verify(rm => rm.DeleteAnnotationById(It.Is<int>(id => id == -1)));
        }
    }
}