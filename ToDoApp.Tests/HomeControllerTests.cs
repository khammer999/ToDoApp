using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using ToDoApp.Controllers;
using ToDoApp.Models;
using Xunit;

namespace ToDoApp.Tests
{
    public class HomeControllerTests
    {
        private IToDoRepository repo;
        private HomeController underTest;

        public HomeControllerTests()
        {
            repo = Substitute.For<IToDoRepository>();
            underTest = new HomeController(repo);
        }




        [Fact]
        public void Index_Returns_A_View()

        {
            var repo = Substitute.For<IToDoRepository>();
            var underTest = new HomeController(repo);
            var result = underTest.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]

        public void Index_Passes_ToDos_To_A_View()
        {
            var expected = new List<ToDo>();

            
            repo.GetAll().Returns(expected);

           
            var result = underTest.Index();
            var model = result.Model;

            Assert.Equal(expected, model);


        }

        [Fact]

        public void Details_Gets_Correct_ToDo()
        {
            var id = 1;

            var result = underTest.Details(id);

            repo.Received().GetById(id);
        }

        [Fact]

        public void Details_Returns_a_View()
        {
            var id = 1;
            var result = underTest.Details(id);
            Assert.IsType<ViewResult>(result);

        }

        [Fact]

        public void Details_Returns_Correct_View()
        {
            var expectedModel = new ToDo();
            var id = 1;
            repo.GetById(id).Returns(expectedModel);

            var result = underTest.Details(id);
            var model = result.Model;
            
            Assert.Same(expectedModel, model);
        }

        [Fact]
        public void Create_Stuff_Making_More_Stuff_Happens()
        {
            var result = underTest.Create();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Saves_Data()
        {
            var userToDoData = new ToDo() { Description = "Hi", DueDate = DateTime.Now };
            underTest.Create(userToDoData);
            repo.Received().Create(userToDoData);
        }

        [Fact]
        public void Create_ReDirects_To_Index()
        {

            var arbitraryToDo = new ToDo();
            var result = underTest.Create(arbitraryToDo);
        } 

        [Fact]
        public void Delete_Returns_A_View()
        {
            var idToDelete = 42;

            var result = underTest.Delete(idToDelete);
            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void Delete_Gets_The_Details()
        {
            var idToDelete = 42;
            var toDoToDelete = new ToDo();
            
            repo.GetById(idToDelete).Returns(toDoToDelete);

            var result = underTest.Details(idToDelete);
            var model = result.Model;

            Assert.Same(toDoToDelete, model);

        }
        [Fact]
        public void DeleteConfirmed_Deletes_The_Todo()
        {
            var id = 42;
            var toDelete = new ToDo();
            repo.GetById(id).Returns(toDelete);

            var result = underTest.DeleteConfirmed(id);

            repo.Received().Delete(toDelete);

        }

        [Fact]
        public void DeleteConfirmed_Redirects_To_Home()
        {
            var result = underTest.DeleteConfirmed(1);
            Assert.IsType<RedirectToActionResult>(result);
        }








    }
}
