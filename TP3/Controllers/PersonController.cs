using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TP3.Models;
using TP3.Models;
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

        
        [HttpPost]
        public IActionResult Search(PersonForm personForm)
        {

            var personService = new PersonService();
            Person person = personService.Search(personForm.Country, personForm.FirstName);
           if(person == null ) {
                ViewBag.resultTable = null;
            }
            else
            {
                ViewBag.resultTable = person;
                return Redirect("/person/"+person.Id);
            }

            return Redirect("/person/all");
           
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var personService = new PersonService();
            Person person = personService.GetPersonById(id);
            if (person == null)
            {
                ViewBag.resultTable = null;
            }
            else
            {
                ViewBag.resultTable = person;
            }
           
            return View(person);
        }


    }
}
