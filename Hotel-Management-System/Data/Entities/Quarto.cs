
namespace Hotel_Management_System.Data.Entities

{

    public class Quarto : IEntity

    {

        public int Id { get; set; }

        public int Numero { get; set; }

        public string Tipo { get; set; }

        public int Capacidade { get; set; }

        public decimal PrecoPorNoite { get; set; }

        public string Estado { get; set; }

    }

}

