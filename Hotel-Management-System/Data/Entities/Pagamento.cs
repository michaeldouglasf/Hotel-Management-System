
namespace Hotel_Management_System.Data.Entities

{

    public class Pagamento : IEntity

    {

        public int Id { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataPagamento { get; set; }

        public string MetodoPagamento { get; set; }

    }

}

