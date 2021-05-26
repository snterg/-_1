using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;
using ЛР_1.Controllers;
using ЛР_1.DAL.Data;
using ЛР_1.DAL.Entities;

namespace ЛР_1.Tests
{
    public class ProductControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests()
        {
            _options =new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "aspnet-ЛР_1-Data").Options;
        }

        [Theory]
        [MemberData(nameof(TClass.Params), MemberType = typeof(TClass))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {

            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;

            //var controller = new ProductController()

            //{ ControllerContext = controllerContext };
            //// Arrange
            //controller._student = TClass.GetStudList();
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TClass.FillContext(context);
            }

            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };
                // Act
                var result = controller.Index(pageNo: page, group: null) as ViewResult;
                var model = result?.Model as List<Course>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].studId);
            }
                // удалить базу данных из памяти
                using (var context = new ApplicationDbContext(_options))
                {
                    context.Database.EnsureDeleted();
                }
            }

        [Fact]
        public void ControllerSelectsGroup()
        {
            //arrange

            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;

            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TClass.FillContext(context);

            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };

                var comparer = Comparer<Course>.GetComparer((d1, d2) =>
                d1.studId.Equals(d2.studId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Course>;
                // assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.Students.ToArrayAsync().GetAwaiter().GetResult()[2], model[0], comparer);

            }
        }
    }
}
