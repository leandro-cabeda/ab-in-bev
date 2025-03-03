using Ambev.DeveloperEvaluation.Application.Services.DTOs;
using Ambev.DeveloperEvaluation.Application.Services.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Serilog;

namespace Ambev.DeveloperEvaluation.Application.Services.Implementations
{
    /*
    * Implementação da interface IUserService
    * 
    */
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        
        /*
        * Método para criar um usuário
        * 
        */
        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            await _userRepository.CreateAsync(user);
            Log.Information("Usuário criado: {@User}", user);
            return _mapper.Map<UserDto>(user);
        }

        
        /*
        * Método para buscar um usuário pelo id
        * 
        */
        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            Log.Information("Usuário buscado: {@User}", user);
            return _mapper.Map<UserDto>(user);
        }

        
        /*
        * Método para deletar um usuário pelo id
        * 
        */
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            Log.Information("Usuário id deletado: {@Id}", id);
            return await _userRepository.DeleteAsync(id);
        }
    }
}
