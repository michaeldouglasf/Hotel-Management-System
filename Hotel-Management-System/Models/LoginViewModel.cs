
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Models

{

    public class LoginViewModel

    {

        [Required(ErrorMessage = "O email é obrigatório.")]

        [EmailAddress(ErrorMessage = "Introduza um email válido.")]

        public string Username { get; set; } = string.Empty;



        [Required(ErrorMessage = "A password é obrigatória.")]

        [DataType(DataType.Password)]

        public string Password { get; set; } = string.Empty;



        [Display(Name = "Manter sessão iniciada")]

        public bool RememberMe { get; set; }

    }

}

