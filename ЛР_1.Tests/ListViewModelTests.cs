using Xunit;
using ЛР_1.DAL.Entities;
using ЛР_1.Models;

namespace ЛР_1.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Course>

            .GetModel(TClass.GetStudList(), 1, 3);

            // Assert
            Assert.Equal(2, model.TotalPages);
        }

        [Theory]
        [MemberData(memberName: nameof(TClass.Params), MemberType = typeof(TClass))]
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Course>.GetModel(TClass.GetStudList(), page, 3);

            // Assert
            Assert.Equal(qty, model.Count);
        }

        [Theory]
        [MemberData(memberName: nameof(TClass.Params), MemberType = typeof(TClass))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Course>

            .GetModel(TClass.GetStudList(), page, 3);

            // Assert
            Assert.Equal(id, model[0].studId);
        }
    }
}
