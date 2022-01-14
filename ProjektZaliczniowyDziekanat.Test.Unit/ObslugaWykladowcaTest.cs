using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using ProjektZaliczeniowyDziekanat.Services;
using Xunit;


namespace ProjektZaliczniowyDziekanat.Test.Unit
{
    public class ObslugaWykladowcaTest
    {

        // Wyswietlzajecia - czy zwraca list
        [Fact]
        public void WyswietlZajecia_ZwracaListe()
        {
            /*         
                     Mock<DziekanatContext> contextStub = new Mock<DziekanatContext>(contextOptionsStub.Object);
                     Wykladowca wykladowca = null;

                     var usersMock = new Mock<DbSet<Wykladowca>>();
                     //usersMock.Setup(x => x.Add(It.IsAny<Wykladowca>())).Returns((Wykladowca u) => u);
                     userContextMock.Setup(x => x.Users.Add(It.IsAny())).Callback(
                     (Wykladowca u) =>
                     {
                         user = u;
                     });
                     contextStub.Setup(x => x.Wykladowcy).Returns(usersMock.Object);*/

            var fixture = new Fixture();

            var users = new List<Wykladowca>
                  {
                    fixture.Build<Wykladowca>().With(u => u.WykladowcaID, 1).Create(),
                    fixture.Build<Wykladowca>().With(u => u.WykladowcaID, 2).Create()
                  }.AsQueryable();
            Mock<DbContextOptions<DziekanatContext>> contextOptionsStub = new Mock<DbContextOptions<DziekanatContext>>();
            var usersMock = new Mock<DbSet<Wykladowca>>();
            usersMock.As<IQueryable<Wykladowca>>().Setup(m => m.Provider).Returns(users.Provider);
            usersMock.As<IQueryable<Wykladowca>>().Setup(m => m.Expression).Returns(users.Expression);
            usersMock.As<IQueryable<Wykladowca>>().Setup(m => m.ElementType).Returns(users.ElementType);
            usersMock.As<IQueryable<Wykladowca>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var userContextMock = new Mock<DziekanatContext>(contextOptionsStub);
            userContextMock.Setup(x => x.Wykladowcy).Returns(usersMock.Object);



            ObslugaWykladowca obsluga = new ObslugaWykladowca();
            

            var result = obsluga.WyswietlZajecia(userContextMock.Object.Wykladowcy.First());

            Assert.IsType<List<Zajecia>>(result);

        }
        // Zalogowany  - czy zwraca null i czy wykladowca
        
        [Fact]
        public void ZalogowanyWykladowca_ZwracaWykladowce()
        {
            Mock<DbContextOptions<DziekanatContext>> contextOptionsStub = new Mock<DbContextOptions<DziekanatContext>>();
            Mock<DziekanatContext> contextStub = new Mock<DziekanatContext>(contextOptionsStub.Object);
            ObslugaWykladowca obsluga = new ObslugaWykladowca(contextStub.Object);

            var result = obsluga.ZalogowanyWykladowca(null);

            Assert.Null(result);
        }


        
        // zalogowanyDTO - czy zwraca null i czy wykladowca
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(8)]
        //[InlineData(null)]
        public void ZalogowanyWykladowcaDTO_ZwracaWykladowce(int? id)
        {
            Mock<DbContextOptions<DziekanatContext>> contextOptionsStub = new Mock<DbContextOptions<DziekanatContext>>();
            Mock<DziekanatContext> contextStub = new Mock<DziekanatContext>(contextOptionsStub.Object);
            IObslugaWykladowca obsluga = new ObslugaWykladowca(contextStub.Object);

            var result = obsluga.ZalogowanyWykladowcaDTO(id);

            Assert.IsType<WykladowcaDTO>(result);
        }


    }
}
