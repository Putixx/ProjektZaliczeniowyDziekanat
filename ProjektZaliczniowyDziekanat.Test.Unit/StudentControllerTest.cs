using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ProjektZaliczeniowyDziekanat.Interfaces;
using ProjektZaliczeniowyDziekanat.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ProjektZaliczniowyDziekanat.Test.Unit
{
    public class StudentControllerTest
    {
        Mock<IObslugaStudent> obslugaStudentStub = new Mock<IObslugaStudent>();

        [Fact]
        public void nazwa()
        {
            StudentController controller = new StudentController(obslugaStudentStub.Object);
            var result = controller.Index() as ViewResult;
            //Assert.NotNull(result);
            Assert.NotNull(result.Model);


        }
    }
}
