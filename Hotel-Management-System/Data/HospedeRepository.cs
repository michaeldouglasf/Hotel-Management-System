
using Hotel_Management_System.Data.Entities;



namespace Hotel_Management_System.Data

{

    public class HospedeRepository : GenericRepository<Hospede>, IHospedeRepository

    {

        public HospedeRepository(DataContext context)

            : base(context)

        {

        }

    }

}

