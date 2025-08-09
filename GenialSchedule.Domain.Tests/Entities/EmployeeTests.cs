using GenialSchedule.Domain.Entities;
using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Tests.Entities
{
    public class EmployeeTests
    {
        private readonly Employee _employee;
        private readonly ServiceType _serviceType;

        public EmployeeTests()
        {
            _serviceType = new ServiceType("Corte de Cabelo", "Corte de cabelo", 20.00M);
            _employee = new Employee("Leon", "leon@cabelo.com", _serviceType);
        }

        [Fact]
        public void CreateEmployee_Should_Create_New_Employee_With_Correct_Data()
        {
            // arrange
            var serviceType = _serviceType;

            // act
            var employee = _employee;

            // assert
            Assert.NotNull(employee);
            Assert.True(employee.Email.Validate());
            Assert.Equal(serviceType, employee.ServiceTypes.First());
            Assert.Equal(default, employee.CreatedAt);
            Assert.Equal(default, employee.UpdateDate);
        }

        [Fact]
        public void CreateEmployee_Should_Not_Create_New_Provider_With_Wrong_Email()
        {
            // arrange
            var serviceType = _serviceType;
            var employee = _employee;

            // act
            employee.Email = new Email("leoncabelo.com");

            // assert
            Assert.NotNull(employee);
            Assert.False(employee.Email.Validate());
            Assert.Equal(serviceType, employee.ServiceTypes.First());
            Assert.Equal(default, employee.CreatedAt);
            Assert.Equal(default, employee.UpdateDate);
        }

        [Fact]
        public void CreateEmployee_Should_Not_Create_New_Provider_With_Wrong_Name()
        {
            // arrange
            var provider = _employee;

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
            var provider = _employee;

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
            var provider = _employee;

            // Act
            provider.RemoveService(_serviceType);

            // Assert
            Assert.DoesNotContain(_serviceType, provider.ServiceTypes);
        }
    }
}