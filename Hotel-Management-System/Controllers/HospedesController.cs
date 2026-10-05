
using Hotel_Management_System.Data;

using Hotel_Management_System.Data.Entities;

using Microsoft.AspNetCore.Mvc;



namespace Hotel_Management_System.Controllers

{

    public class HospedesController : Controller

    {

        private readonly IHospedeRepository _hospedeRepository;



        public HospedesController(IHospedeRepository hospedeRepository)

        {

            _hospedeRepository = hospedeRepository;

        }



        [HttpGet]

        public IActionResult Index()

        {

            return View(_hospedeRepository.GetAll());

        }



        public async Task<IActionResult> Details(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }



            var hospede = await _hospedeRepository.GetByIdAsync(id.Value);



            if (hospede == null)

            {

                return NotFound();

            }



            return View(hospede);

        }



        public IActionResult Create()

        {

            return View();

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Hospede hospede)

        {

            if (ModelState.IsValid)

            {

                await _hospedeRepository.CreateAsync(hospede);

                return RedirectToAction(nameof(Index));

            }



            return View(hospede);

        }



        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }



            var hospede = await _hospedeRepository.GetByIdAsync(id.Value);



            if (hospede == null)

            {

                return NotFound();

            }



            return View(hospede);

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Hospede hospede)

        {

            if (ModelState.IsValid)

            {

                await _hospedeRepository.UpdateAsync(hospede);

                return RedirectToAction(nameof(Index));

            }



            return View(hospede);

        }



        public async Task<IActionResult> Delete(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }



            var hospede = await _hospedeRepository.GetByIdAsync(id.Value);



            if (hospede == null)

            {

                return NotFound();

            }



            await _hospedeRepository.DeleteAsync(hospede);



            return RedirectToAction(nameof(Index));

        }

    }

}

