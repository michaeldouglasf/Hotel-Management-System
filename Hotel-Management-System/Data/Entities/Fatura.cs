
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class Fatura : IEntity

    {

        public int Id { get; set; }



        [Required]

        [MaxLength(30)]

        public string Numero { get; set; } = string.Empty;



        [Required]

        public DateTime DataEmissao { get; set; }



        [Required]

        public decimal ValorTotal { get; set; }



        public Reserva? Reserva { get; set; }

    }

}

