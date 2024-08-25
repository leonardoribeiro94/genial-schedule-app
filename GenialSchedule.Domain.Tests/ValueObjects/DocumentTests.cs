using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.ValueObjects
{
    public class DocumentTests
    {
        [Fact]
        public void Should_Return_Sucess_When_Informing_Valid_Document()
        {
            // arrange
            var personDocument = new PersonDocument("01234567890");

            // act
            var isValid = personDocument.Validate();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void Should_Return_Error_When_Informing_Invalid_Document()
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