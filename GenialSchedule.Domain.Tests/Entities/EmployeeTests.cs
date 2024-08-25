using GenialSchedule.Domain.Entities;
using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.Entities
{
    public class EmployeeTests
    {
        private readonly Employee _provider;
        private readonly ServiceType _serviceType;

        public EmployeeTests()
        {
            _serviceType = new ServiceType("Corte de Cabelo", "Corte de cabelo", 20.00M);
            _provider = new Employee("Leon", new Email("leon@cabelo.com"), _serviceType);
        }

        [Fact]
        public void CreateProvider_Should_Create_New_Provider_With_Correct_Data()
        {
            // arrange
            var serviceType = _serviceType;

            // act
            var provider = _provider;

            // assert
            Assert.NotNull(provider);
            Assert.True(provider.Email.Validate());
            Assert.Equal(serviceType, provider.ServiceTypes.First());
            Assert.Equal(default, provider.CreateDate);
            Assert.Equal(default, provider.UpdateDate);
        }

        [Fact]
        public void CreateProvider_Should_Not_Create_New_Provider_With_Wrong_Email()
        {
            // arrange
            var serviceType = _serviceType;
            var provider = _provider;

            // act
            provider.Email = new Email("leoncabelo.com");

            // assert
            Assert.NotNull(provider);
            Assert.False(provider.Email.Validate());
            Assert.Equal(serviceType, provider.ServiceTypes.First());
            Assert.Equal(default, provider.CreateDate);
            Assert.Equal(default, provider.UpdateDate);
        }

        [Fact]
        public void CreateProvider_Should_Not_Create_New_Provider_With_Wrong_Name()
        {
            // arrange
            var provider = _provider;

            // act
            provider.Name = new Name("");

            // assert
            Assert.NotNull(provider);
            Assert.False(provider.Name.Validate());
        }

        [Fact]
        public void AddNewService_Should_Add_ServiceType()
        {
            // Arrange
            var provider = _provider;

            // Act
            var serviceType = new ServiceType("Corte de Barba", "Corte de Barba", 15);
            provider.AddNewService(serviceType);

            // Assert
            Assert.Contains(serviceType, provider.ServiceTypes);
        }

        [Fact]
        public void RemoveService_Should_Remove_ServiceType()
        {
            // Arrange
            var provider = _provider;

            // Act
            provider.RemoveService(_serviceType);

            // Assert
            Assert.DoesNotContain(_serviceType, provider.ServiceTypes);
        }
    }
}