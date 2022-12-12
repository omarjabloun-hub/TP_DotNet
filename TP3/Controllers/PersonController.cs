using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
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
        public IActionResult Search(Person personf)
        {

            var personService = new PersonService();
            List<Person> persons = personService.GetAllPerson();
            foreach(var person in persons)
            {
                if(person.Country == personf.Country && person.FirstName == personf.FirstName)
                {
                    return Redirect("/person/{person.Id}");
                }
            }

            return Redirect("/person/all");
           
        }

        [HttpGet("{id}")]
        public ActionResult Index(int id)
        {
            var personService = new PersonService();
            Person person = personService.GetPersonById(id);
            
            return View(person);
        }


    }
}
