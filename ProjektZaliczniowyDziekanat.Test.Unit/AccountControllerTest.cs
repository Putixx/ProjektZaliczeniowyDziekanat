using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjektZaliczeniowyDziekanat.Controllers;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjektZaliczniowyDziekanat.Test.Unit
{
    public class AccountControllerTest
    {
        Mock<IObslugaAccount> obslugaAccountStub = new Mock<IObslugaAccount>();

        [Fact]
        public void LoginWykladowcy_BrakOdwolania_ZwracaBadRequest()
        {
            //Arrange
            AccountController controller = new AccountController(obslugaAccountStub.Object);
            WykladowcaLogowanie loginWykladowcy = new WykladowcaLogowanie() { Login = "login", Haslo = "haslo" };
            //Act

            var result = controller.LoginWykladowcy(loginWykladowcy.Login, loginWykladowcy.Haslo);
            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void LoginStudenta_BrakOdwolania_ZwracaBadRequest()
        {
            //Arrange
            AccountController controller = new AccountController(obslugaAccountStub.Object);
            StudentLogowanie loginStudenta = new StudentLogowanie() { Login = "login", Haslo = "haslo" };
            //Act

            var result = controller.LoginWykladowcy(loginStudenta.Login, loginStudenta.Haslo);
            //Assert

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
