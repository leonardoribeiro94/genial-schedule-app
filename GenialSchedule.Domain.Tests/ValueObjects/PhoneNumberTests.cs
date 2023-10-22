using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.ValueObjects
{
    public class PhoneNumberTests
    {
        [Fact]
        public void ShouldReturnSucessWhenInformingValidPhoneNumber()
        {
            // arrange
            var phoneNumber = new PhoneNumber("11978597867");

            // act
            var isValid = phoneNumber.Validate();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenInformingInvalidPhoneNumber()
        {
            // arrange
            var phoneNumber = new PhoneNumber("11978g97867");

            // act
            var isValid = phoneNumber.Validate();

            // assert
            Assert.False(isValid);
        }
    }
}