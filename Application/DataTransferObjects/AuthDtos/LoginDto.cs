// Ignore Spelling: Dto Dtos

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects.AuthDtos
{
    public record LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "password is required")]
        public string? Password { get; init; }

    }
}
