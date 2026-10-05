
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class Quarto : IEntity

    {

        public int Id { get; set; }



        [Required]

        public int Numero { get; set; }



        [Required]

        [MaxLength(30)]

        public string Tipo { get; set; } = string.Empty;



        [Required]

        public int Capacidade { get; set; }



        [Required]

        public decimal PrecoPorNoite { get; set; }



        [Required]

        [MaxLength(30)]

        public string Estado { get; set; } = "Livre";



        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    }

}

