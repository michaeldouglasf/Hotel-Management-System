
using Hotel_Management_System.Data.Entities;

using Microsoft.AspNetCore.Identity;



namespace Hotel_Management_System.Helpers

{

    public interface IUserHelper

    {

        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

    }

}

