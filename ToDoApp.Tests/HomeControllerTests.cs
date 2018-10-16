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

            var repo = Substitute.For<IToDoRepository>();
            repo.GetAll().Returns(expected);

            var underTest = new HomeController(repo);
            var result = underTest.Index();
            var model = result.Model;

            Assert.Equal(expected, model);


        }





    }
}
