
namespace Hotel_Management_System.Data.Entities

{

    public class Reserva : IEntity

    {

        public int Id { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; }

        public string TipoQuarto { get; set; }

        public int NumeroHospedes { get; set; }

        public string Estado { get; set; }

    }

}

