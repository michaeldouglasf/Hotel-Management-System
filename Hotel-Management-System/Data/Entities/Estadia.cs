
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class Estadia : IEntity

    {

        public int Id { get; set; }



        [Required]

        public DateTime CheckIn { get; set; }



        public DateTime? CheckOut { get; set; }



        public decimal ValorTotal { get; set; }



        public Reserva? Reserva { get; set; }

    }

}

