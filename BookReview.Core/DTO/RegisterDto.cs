using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "El UserName no puede estar vacio")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Email no puede estar vacio")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        public string? PhotoUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña no puede estar vacia")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña no puede estar vacia")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

}
