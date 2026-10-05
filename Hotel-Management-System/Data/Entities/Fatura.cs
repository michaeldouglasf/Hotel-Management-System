
namespace Hotel_Management_System.Data.Entities

{

    public class Fatura : IEntity

    {

        public int Id { get; set; }

        public string Numero { get; set; }

        public DateTime DataEmissao { get; set; }

        public decimal ValorTotal { get; set; }

    }

}

