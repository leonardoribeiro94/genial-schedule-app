using GenialSchedule.Application.DTOs.Users;

namespace GenialSchedule.Application.Usecases.User
{
    public interface ICreateUserUseCase
    {
        Task ExecuteAsync(CreateUserRequest request);
    }
}