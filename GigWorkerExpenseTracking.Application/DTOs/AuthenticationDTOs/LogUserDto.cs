using System.ComponentModel.DataAnnotations;

namespace GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs
{
    public class LogUserDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
