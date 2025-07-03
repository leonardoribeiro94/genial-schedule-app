using GenialSchedule.Application.DTOs.Users;

namespace GenialSchedule.Application.Usecases.User.Commands
{
    public interface ICreateUserUseCase : IUsecase
    {
        Task ExecuteAsync(CreateUserRequest request);
    }
}