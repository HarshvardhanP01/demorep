using Microsoft.AspNetCore.Mvc;
using MVC_DEMO.Models;
using System.Diagnostics;
namespace MVC_DEMO.Controllers
{
    public class HomeController : Controller
    {
        /* public string Index()
         {
             return "Hello Harshvardhan";
         }*/
        public ContentResult Index()
        {
            return Content("<h1 style='color:orange'>Hello Harshvardhan</h1>", "text/HTML"); //dynamic untyped view...
        }

        public ViewResult Index1()
        {
            ViewData.Add("data1", "Dynamic ViewData");

            ViewBag.data2 = "ViewBag";
            return View(); 
        }

        public IActionResult GetPerson()
        { 
            Person person = new Person();
            person.ID = 1;
            person.Name = "ABC";
            person.DOB = DateTime.Parse("10-June-1996");
            return View(person);
        }
        /*
                [HttpPost]
                public IActionResult GetPerson(IFormCollection form)
                {
                    Person p = new Person()
                    {
                        ID = int.Parse(form["ID"]),
                        Name = form["Name"],
                        DOB = DateTime.Parse(form["DOB"])
                    };
                    Console.WriteLine(p.ID);
                    Console.WriteLine(p.Name);
                    Console.WriteLine(p.DOB);
                    return View();
                }*/

        [HttpPost]
        public IActionResult GetPerson([FromForm] Person p)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine(p.ID);
                Debug.WriteLine(p.Name);
                Debug.WriteLine(p.DOB);
                return View(); 
            }
            else
            {
                return View(p);
            }
        }
    }
}
