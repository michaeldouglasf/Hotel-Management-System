
using System.ComponentModel.DataAnnotations;



namespace Hotel_Management_System.Data.Entities

{

    public class Reserva : IEntity

    {

        public int Id { get; set; }



        [Required]

        public DateTime DataEntrada { get; set; }



        [Required]

        public DateTime DataSaida { get; set; }



        [Required]

        [MaxLength(30)]

        public string TipoQuarto { get; set; } = string.Empty;



        [Required]

        public int NumeroHospedes { get; set; }



        [Required]

        [MaxLength(30)]

        public string Estado { get; set; } = "Pendente";



        public decimal ValorTotal { get; set; }



        public Quarto? Quarto { get; set; }



        public Hospede? Hospede { get; set; }



        public Estadia? Estadia { get; set; }



        public Fatura? Fatura { get; set; }



        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();



        public ICollection<ServicoExtra> ServicosExtras { get; set; } = new List<ServicoExtra>();

    }

}

