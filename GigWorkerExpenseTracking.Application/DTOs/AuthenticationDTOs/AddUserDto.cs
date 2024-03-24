using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs
{
    public class AddUserDto
    {
        [Required]
        public string? FirstName { get;  set; }
        [Required]
        public string? LastName { get;  set; }
        [Required]
        public string? Username { get;  set; }
        [Required]
        public string? Email { get;  set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? Confirmpassword { get; set; }
    }
}
