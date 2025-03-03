using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Services.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Services.Interfaces
{
    /// <summary>
    /// Interface para o serviço de usuário
    /// </summary>
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
