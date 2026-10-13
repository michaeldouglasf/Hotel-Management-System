
using Hotel_Management_System.Data.Entities;

using Microsoft.AspNetCore.Identity;



namespace Hotel_Management_System.Data.SeedWork

{

    public class SeedDb

    {

        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;



        public SeedDb(

            UserManager<User> userManager,

            RoleManager<IdentityRole> roleManager)

        {

            _userManager = userManager;

            _roleManager = roleManager;

        }



        public async Task SeedAsync()

        {

            await EnsureRoleAsync("Admin");

            await EnsureRoleAsync("User");



            const string email = "admin@hotel.com";

            const string password = "Admin123!";



            var admin = await _userManager.FindByEmailAsync(email);



            if (admin == null)

            {

                admin = new User

                {

                    UserName = email,

                    Email = email,

                    FirstName = "Administrador",

                    LastName = "Hotel",

                    EmailConfirmed = true

                };



                var createResult = await _userManager.CreateAsync(

                    admin, password);



                if (!createResult.Succeeded)

                {

                    var errors = string.Join(

                        "; ",

                        createResult.Errors.Select(e => e.Description));



                    throw new InvalidOperationException(

                        $"Erro ao criar administrador: {errors}");

                }

            }



            if (!await _userManager.IsInRoleAsync(admin, "Admin"))

            {

                var roleResult = await _userManager.AddToRoleAsync(

                    admin, "Admin");



                if (!roleResult.Succeeded)

                {

                    var errors = string.Join(

                        "; ",

                        roleResult.Errors.Select(e => e.Description));



                    throw new InvalidOperationException(

                        $"Erro ao atribuir papel Admin: {errors}");

                }

            }



            Console.WriteLine("SeedDb executado com sucesso.");

        }



        private async Task EnsureRoleAsync(string roleName)

        {

            if (await _roleManager.RoleExistsAsync(roleName))

            {

                return;

            }



            var result = await _roleManager.CreateAsync(

                new IdentityRole(roleName));



            if (!result.Succeeded)

            {

                var errors = string.Join(

                    "; ",

                    result.Errors.Select(e => e.Description));



                throw new InvalidOperationException(

                    $"Erro ao criar papel {roleName}: {errors}");

            }

        }

    }

}

