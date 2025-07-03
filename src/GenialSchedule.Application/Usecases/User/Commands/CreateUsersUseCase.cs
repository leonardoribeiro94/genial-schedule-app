using AutoMapper;
using GenialSchedule.Application.DTOs.Users;

namespace GenialSchedule.Application.Usecases.User.Commands;

public class CreateUsersUseCase : ICreateUserUseCase
{
    public async Task ExecuteAsync(CreateUserRequest request)
    {
        // valida e-mail já existente

        // criptografia da informação
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // envio para o repository
    }
}