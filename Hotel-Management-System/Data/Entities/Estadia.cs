
namespace Hotel_Management_System.Data.Entities

{

    public class Estadia : IEntity

    {

        public int Id { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public decimal ValorTotal { get; set; }

    }

}

