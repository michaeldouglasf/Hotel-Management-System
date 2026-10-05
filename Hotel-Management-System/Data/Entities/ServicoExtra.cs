
namespace Hotel_Management_System.Data.Entities

{

    public class ServicoExtra : IEntity

    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

    }

}

