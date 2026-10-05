
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class Hospede : IEntity

    {

        public int Id { get; set; }



        [Required]

        [MaxLength(100)]

        public string Nome { get; set; } = string.Empty;



        [Required]

        [MaxLength(30)]

        public string Contacto { get; set; } = string.Empty;



        [Required]

        [EmailAddress]

        [MaxLength(100)]

        public string Email { get; set; } = string.Empty;



        [Required]

        [MaxLength(30)]

        public string DocumentoIdentificacao { get; set; } = string.Empty;



        public User? User { get; set; }



        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    }

}

