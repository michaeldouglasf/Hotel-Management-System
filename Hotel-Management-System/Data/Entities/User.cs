
using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class User : IdentityUser

    {

        [Required]

        [MaxLength(50)]

        public string FirstName { get; set; } = string.Empty;



        [Required]

        [MaxLength(50)]

        public string LastName { get; set; } = string.Empty;



        [Display(Name = "Nome")]

        public string FullName => $"{FirstName} {LastName}";



        public string? Foto { get; set; }

    }

}

