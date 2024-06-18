using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;
using System.Linq;
using NUnit.Framework;


namespace CRUD_application_2.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController controller;

        [SetUp]
        public void Setup()
        {
            // Initialize UserController before each test
            controller = new UserController();
            // Reset the userlist to a known state before each test
            UserController.userlist.Clear();
            UserController.userlist.AddRange(new[]
            {
                new User { Id = 1, Name = "Test User 1", Email = "test1@example.com" },
                new User { Id = 2, Name = "Test User 2", Email = "test2@example.com" }
            });
        }

        [Test]
        public void Index_ReturnsViewWithAllUsers()
        {
            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model as System.Collections.Generic.List<User>;

            // Assert
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Count, Is.EqualTo(2));

        }

        [Test]
        public void Details_UserExists_ReturnsViewWithUser()
        {
            // Act
            var result = controller.Details(1) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.That(result, Is.Not.Null); // Alternative for Assert.IsNotNull
            Assert.That(model.Id, Is.EqualTo(1)); // Alternative for Assert.AreEqual
        }

        [Test]
        public void Details_UserDoesNotExist_ReturnsHttpNotFound()
        {
            // Act
            var result = controller.Details(999);

            // Assert
            Assert.That(result, Is.InstanceOf<HttpNotFoundResult>());
        }

        [Test]
        public void Create_PostValidUser_RedirectsToIndex()
        {
            // Arrange
            var newUser = new User { Id = 3, Name = "New User", Email = "newuser@example.com" };

            // Act
            var result = controller.Create(newUser) as RedirectToRouteResult;
            // Assert
            Assert.That(result, Is.Not.Null); // Fix for Problem 1
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index")); // Fix for Problem 2
            Assert.That(UserController.userlist.Count, Is.EqualTo(3));
        }

        [Test]
        public void Edit_PostValidUser_RedirectsToIndex()
        {
            // Arrange
            var updatedUser = new User { Id = 1, Name = "Updated User", Email = "updated@example.com" };

            // Act
            var result = controller.Edit(updatedUser.Id, updatedUser) as RedirectToRouteResult;

            // Assert
            Assert.That(result, Is.Not.Null); // Corrected for Problem 1
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index")); // Corrected for Problem 2
            Assert.That(UserController.userlist.First(u => u.Id == 1).Name, Is.EqualTo("Updated User")); // Corrected for Problem 3
        }

        [Test]
        public void Delete_ValidUser_RedirectsToIndex()
        {
            // Act
            var result = controller.Delete(1, null) as RedirectToRouteResult;

            // Assert
            // Assert
            Assert.That(result, Is.Not.Null); // Corrected for Problem 1
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index")); // Corrected for Problem 2
            Assert.That(UserController.userlist.Count, Is.EqualTo(1));
        }
    }
}
