using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void Should_Return_Success_When_Valid_Data()
        {
            var name = new Name("Leon Cabelo Santos");

            Assert.True(name.Validate());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("leo")]
        public void Should_Return_False_When_InValid_Data(string completeName)
        {
            var name = new Name(completeName);

            Assert.False(name.Validate());
        }
    }
}