using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void ShouldReturnTrueWhenInformedValidEmail()
        {
            // arrange
            var email = new Email("test@gmail.com");

            // act
            var isValid = email.Validate();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalseWhenInformedInvalidEmail()
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