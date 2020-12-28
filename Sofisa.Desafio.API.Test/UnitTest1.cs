using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sofisa.Desafio.API.Controllers;
using Sofisa.Desafio.API.Models;
using System.Data.Entity;

namespace Sofisa.Desafio.API.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var mockSet = new Mock<DbSet<Repositorio>>();

            var mockContext = new Mock<RepositorioContext>();
            mockContext.Setup(m => m.Repositorios).Returns(mockSet.Object);

            var service = new FavoritosController(mockContext.Object);
            var xx=service.ObterListaDeFavoritos();
        }
    }
}
