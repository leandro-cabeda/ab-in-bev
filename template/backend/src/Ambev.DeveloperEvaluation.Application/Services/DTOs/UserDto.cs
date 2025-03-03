using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Services.DTOs
{
    /* 
    * Classe DTO para o usuário
    * 
    */
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public UserStatus Status { get; set; }

        public UserRole Role { get; set; }

    }

    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public UserStatus Status { get; set; }

        public UserRole Role { get; set; }

    }
}
