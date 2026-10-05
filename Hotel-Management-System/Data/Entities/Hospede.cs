
namespace Hotel_Management_System.Data.Entities

{

    public class Hospede : IEntity

    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Contacto { get; set; }

        public string Email { get; set; }

        public string DocumentoIdentificacao { get; set; }

    }

}

