using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void Should_Return_True_When_Informed_Valid_Email()
        {
            // arrange
            var email = new Email("test@gmail.com");

            // act
            var isValid = email.Validate();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void Should_Return_False_When_Informed_Invalid_Email()
        {
            // arrange
            var email = new Email("test.gmail.com");

            // act
            var isValid = email.Validate();

            // assert
            Assert.False(isValid);
        }
    }
}