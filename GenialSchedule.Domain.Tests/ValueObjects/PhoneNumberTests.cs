using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.ValueObjects
{
    public class PhoneNumberTests
    {
        [Fact]
        public void CreatePhoneNumber_Should_Return_Sucess_With_Correct_PhoneNumber()
        {
            // arrange
            var phoneNumber = new PhoneNumber("11978597867");

            // act
            var isValid = phoneNumber.Validate();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void CreatePhoneNumber_Should_Return_Error_With_Invalid_PhoneNumber()
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