using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.ValueObjects
{
    public class DocumentTests
    {
        [Fact]
        public void ShouldReturnSucessWhenInformingValidDocument()
        {
            // arrange
            var personDocument = new PersonDocument("01234567890");

            // act
            var isValid = personDocument.Validate();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenInformingInvalidDocument()
        {
            // arrange
            var personDocument = new PersonDocument("746537436567");

            // act
            var isValid = personDocument.Validate();

            // assert
            Assert.False(isValid);
        }
    }
}