using ContactTask.Services.Contract;
using ContactTask.ViewModels;
using ContactTask.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactTask.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result= await _contactService.Login(loginViewModel);

            if(result==-1)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View();
            }

            return   RedirectToAction("Index", "Contact");

        }



        public async Task<IActionResult> Index([FromQuery] int page =1)
        {
            var Contact = await _contactService.Readall(page,5);

            var all = await _contactService.allcount();

            var pagecount = (int)((all+5) / 5);

                ViewBag.pagecount = pagecount;
               ViewBag.page = page;

            return View(Contact);
        }

   


        [HttpGet]
        public async Task<IActionResult> CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(AddContactViewModel addContactViewModel)
        {
            if (ModelState.IsValid)
            {

                await _contactService.create(addContactViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(addContactViewModel);
        }



        [HttpGet]
        public async Task<IActionResult> EditContact(int id)
        {
            ContactViewModel contact = await _contactService.Readbyid(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Json(new { data = contact });
        }




        [HttpPost]
        public async Task<IActionResult> EditContact( [FromBody]EditContactViewModel editContactViewModel)
        {

            
             var result=   await _contactService.Update(editContactViewModel);

             
                return Json(new { data = result });
            


        }




     



        [HttpDelete]
        public async Task<IActionResult> deleteContact(int id)
        {
            var result = await _contactService.delete(id);

            return Json(new { data = result });
        }





    }
}
