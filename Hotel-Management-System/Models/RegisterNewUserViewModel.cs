
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Models

{

    public class RegisterNewUserViewModel

    {

        [Required(ErrorMessage = "O primeiro nome é obrigatório.")]

        [Display(Name = "Primeiro nome")]

        public string FirstName { get; set; } = string.Empty;



        [Required(ErrorMessage = "O apelido é obrigatório.")]

        [Display(Name = "Apelido")]

        public string LastName { get; set; } = string.Empty;



        [Required(ErrorMessage = "O email é obrigatório.")]

        [EmailAddress(ErrorMessage = "Introduza um email válido.")]

        public string Username { get; set; } = string.Empty;



        [Required(ErrorMessage = "A password é obrigatória.")]

        [StringLength(100, MinimumLength = 6,

            ErrorMessage = "A password deve ter pelo menos 6 caracteres.")]

        [DataType(DataType.Password)]

        public string Password { get; set; } = string.Empty;



        [Required(ErrorMessage = "Confirme a password.")]

        [DataType(DataType.Password)]

        [Compare(nameof(Password), ErrorMessage = "As passwords não coincidem.")]

        [Display(Name = "Confirmar password")]

        public string Confirm { get; set; } = string.Empty;

    }

}

