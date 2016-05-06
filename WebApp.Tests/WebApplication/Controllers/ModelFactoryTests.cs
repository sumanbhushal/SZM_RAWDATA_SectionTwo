using System;
using System.Web.Http.Routing;
using Moq;
using NUnit.Framework;
using DomainModel;
using WebApplication.Controllers;

namespace WebApp.Tests.WebApplication.Controllers
{
    public class ModelFactoryTest
    {
        [Test]
        public void MapAnnotation_AnnotationModel()
        {
            //Arrange
            var urlHelperMock = new Mock<UrlHelper>();
            urlHelperMock.Setup(uhm => uhm.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("Link");

            var annotation = new Annotation
            {
                Id = 1,
                PostId = 19,
                CommentId = 49,
                AnnotationDescription = "testing",
                AnnotationCreateDate = new DateTime(2015, 5, 6)
            };

            //Act
            var AnnotationModel = ModelFactory.Map(annotation, urlHelperMock.Object);

            //Assert
            Assert.AreEqual("Link", AnnotationModel.Url, "Url");
            Assert.AreEqual(19, AnnotationModel.PostId, "PostId");
            Assert.AreEqual(49, AnnotationModel.CommentId, "CommentId");
            Assert.AreEqual("testing", AnnotationModel.AnnotationDescription, "AnnotationDescription");
            Assert.AreEqual(new DateTime(2015, 5, 6), AnnotationModel.AnnotationCreateDate, "AnnotationCreateDate");
            urlHelperMock.Verify(uhm => uhm.Link(
                It.Is<string>(x => x == "AnnotationsApi"),
                It.Is<object>(x => x.GetType().GetProperty("id").GetValue(x).ToString() == "1")), Times.Once);
        }
    }
}