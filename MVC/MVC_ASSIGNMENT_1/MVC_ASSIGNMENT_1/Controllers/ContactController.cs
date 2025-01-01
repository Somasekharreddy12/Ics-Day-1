using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC_ASSIGNMENT_1.Models;
using MVC_ASSIGNMENT_1.Repository;


namespace MVC_ASSIGNMENT_1.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository repository; 
        public ContactController()
        {
            repository = new ContactRepository();
        }
        public async Task<ActionResult> Index()
        {
            var contacts = await repository.GetAllAsync();
            return View(contacts);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
       
    }
}