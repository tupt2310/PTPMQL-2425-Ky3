using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class EmployeeController : Controller
    { 
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            return View();
        } 
        // GET: /HelloWorld/Welcome/ 

        public string Employee()
        {
            return "This is the Welcome action method...";
        }
    }
}