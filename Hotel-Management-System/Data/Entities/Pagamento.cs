
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class Pagamento : IEntity

    {

        public int Id { get; set; }



        [Required]

        public decimal Valor { get; set; }



        [Required]

        public DateTime DataPagamento { get; set; }



        [Required]

        [MaxLength(30)]

        public string MetodoPagamento { get; set; } = string.Empty;



        public Reserva? Reserva { get; set; }

    }

}

