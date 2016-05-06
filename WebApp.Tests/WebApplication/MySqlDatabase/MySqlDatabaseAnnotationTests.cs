using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using MySqlDatabase;
using NUnit.Framework;

namespace WebApp.Tests.WebApplication.MySqlDatabase
{
    public class MySqlRepositoryAnnotationTest
    {

        [Test]
        public void Update_Annotation()
        {
            //Arrange
            var repository = new MySqlRepository();
            var annotation = new Annotation { PostId = 19 };

            //Act
            annotation.PostId = 29;
            repository.UpdateAnnotation(annotation);

            //Assert
            Assert.AreEqual(29, repository.FindAnnotationById(annotation.Id));

            repository.DeleteAnnotationById(annotation.Id);
        }
        [Test]
        public void DeleteAnnotationById_RemoveAnnotation()
        {
            //Arrange
            var repository = new MySqlRepository();
            var annotation = new Annotation
            {
                PostId = 19,
                CommentId = 49,
                AnnotationDescription = "Testing",
                AnnotationCreateDate = new DateTime(2015, 6, 6)
            };
            repository.InsertNewAnnotation(annotation);

            //Act
            repository.DeleteAnnotationById(annotation.Id);

            //Assert
            Assert.Null(repository.FindAnnotationById(annotation.Id));
        }
    }
}