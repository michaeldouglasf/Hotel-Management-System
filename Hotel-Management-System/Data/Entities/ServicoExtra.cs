
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class ServicoExtra : IEntity

    {

        public int Id { get; set; }



        [Required]

        [MaxLength(50)]

        public string Nome { get; set; } = string.Empty;



        [MaxLength(200)]

        public string? Descricao { get; set; }



        [Required]

        public decimal Preco { get; set; }



        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    }

}

