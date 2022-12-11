using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP3.Services;

namespace TP3.Controllers
{
    [Route("[controller]")]
    public class PersonController : Controller
    {

        // GET: Person/all
        [HttpGet("all")]
        public ActionResult all()
        {
            var personService = new PersonService();

            return View(personService.GetAllPerson());
        }


    }
}
