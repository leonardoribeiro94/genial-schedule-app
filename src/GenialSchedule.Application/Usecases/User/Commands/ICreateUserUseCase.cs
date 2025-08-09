using GenialSchedule.Application.DTOs.Users;
using GenialSchedule.Application.Usecases.Abstractions;

namespace GenialSchedule.Application.Usecases.User.Commands
{
    public interface ICreateUserUseCase : IUsecase
    {
        Task ExecuteAsync(CreateUserRequest request);
    }
}