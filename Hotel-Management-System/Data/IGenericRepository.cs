
using Hotel_Management_System.Data.Entities;



namespace Hotel_Management_System.Data

{

    public interface IGenericRepository<T> where T : class, IEntity

    {

        IQueryable<T> GetAll();



        Task<T?> GetByIdAsync(int id);



        Task CreateAsync(T entity);



        Task UpdateAsync(T entity);



        Task DeleteAsync(T entity);



        Task<bool> ExistAsync(int id);

    }

}

