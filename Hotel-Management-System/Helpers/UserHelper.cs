
using Hotel_Management_System.Data.Entities;

using Hotel_Management_System.Models;

using Microsoft.AspNetCore.Identity;



namespace Hotel_Management_System.Helpers

{

    public class UserHelper : IUserHelper

    {

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;



        public UserHelper(

            UserManager<User> userManager,

            SignInManager<User> signInManager)

        {

            _userManager = userManager;

            _signInManager = signInManager;

        }



        public async Task<User?> GetUserByEmailAsync(string email)

        {

            return await _userManager.FindByEmailAsync(email);

        }



        public async Task<IdentityResult> AddUserAsync(

            User user, string password)

        {

            return await _userManager.CreateAsync(user, password);

        }



        public async Task<SignInResult> LoginAsync(LoginViewModel model)

        {

            var user = await _userManager.FindByEmailAsync(model.Username);



            if (user == null)

            {

                return SignInResult.Failed;

            }



            return await _signInManager.PasswordSignInAsync(

                user,

                model.Password,

                model.RememberMe,

                lockoutOnFailure: true);

        }



        public async Task LogoutAsync()

        {

            await _signInManager.SignOutAsync();

        }

    }

}

