
using Hotel_Management_System.Data.Entities;

using Hotel_Management_System.Helpers;

using Hotel_Management_System.Models;

using Microsoft.AspNetCore.Mvc;



namespace Hotel_Management_System.Controllers

{

    public class AccountController : Controller

    {

        private readonly IUserHelper _userHelper;



        public AccountController(IUserHelper userHelper)

        {

            _userHelper = userHelper;

        }



        [HttpGet]

        public IActionResult Login(string? returnUrl = null)

        {

            ViewData["ReturnUrl"] = returnUrl;

            return View();

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(

            LoginViewModel model, string? returnUrl = null)

        {

            ViewData["ReturnUrl"] = returnUrl;



            if (!ModelState.IsValid)

            {

                return View(model);

            }



            var result = await _userHelper.LoginAsync(model);



            if (result.Succeeded)

            {

                if (!string.IsNullOrWhiteSpace(returnUrl) &&

                    Url.IsLocalUrl(returnUrl))

                {

                    return Redirect(returnUrl);

                }



                return RedirectToAction("Index", "Home");

            }



            ModelState.AddModelError(

                string.Empty,

                "Email ou password incorretos.");



            return View(model);

        }



        [HttpGet]

        public IActionResult Register()

        {

            return View();

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(

            RegisterNewUserViewModel model)

        {

            if (!ModelState.IsValid)

            {

                return View(model);

            }



            var existingUser =

                await _userHelper.GetUserByEmailAsync(model.Username);



            if (existingUser != null)

            {

                ModelState.AddModelError(

                    nameof(model.Username),

                    "Já existe uma conta com este email.");



                return View(model);

            }



            var user = new User

            {

                UserName = model.Username,

                Email = model.Username,

                FirstName = model.FirstName,

                LastName = model.LastName,

                EmailConfirmed = true

            };



            var result = await _userHelper.AddUserAsync(

                user, model.Password);



            if (result.Succeeded)

            {

                TempData["SuccessMessage"] =

                    "Conta criada com sucesso. Já pode iniciar sessão.";



                return RedirectToAction(nameof(Login));

            }



            foreach (var error in result.Errors)

            {

                ModelState.AddModelError(string.Empty, error.Description);

            }



            return View(model);

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Logout()

        {

            await _userHelper.LogoutAsync();

            return RedirectToAction("Index", "Home");

        }

    }

}

