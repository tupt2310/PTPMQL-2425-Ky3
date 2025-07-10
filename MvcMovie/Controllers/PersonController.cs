using Microsoft.AspNetCore.Mvc;
using MvcMovie.Model;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public PersonController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            // Sinh mã PersonId tự động
            int count = _context.Persons.Count();
            string newPersonId = $"PS{(count + 1).ToString("D3")}";
            var person = new MvcMovie.Model.Person { PersonId = newPersonId };
            return View(person);
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MvcMovie.Model.Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }


        [HttpPost]
        public IActionResult Index(Person ps)
        {
            // Nếu PersonId chưa có, tự động sinh mã mới
            if (string.IsNullOrEmpty(ps.PersonId))
            {
                int count = _context.Persons.Count();
                ps.PersonId = $"PS{(count + 1).ToString("D3")}";
            }
            string strOutput = "Xin chào " + ps.PersonId + " - " + ps.FullName + " - " + ps.Address;
            ViewBag.infoPerson = strOutput;
            return View();
        }
    }
}