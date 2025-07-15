using Microsoft.AspNetCore.Mvc;
using MvcMovie.Model;
using MvcMovie.Models.Process;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        private readonly Data.ApplicationDbContext _context;
        private ExcelProcess _excelProcess= new ExcelProcess();

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
        public IActionResult Upload()
        {
            return View();
        }
            [HttpPost]
            [ValidateAntiForgeryToken]
public async Task<IActionResult> Upload(IFormFile file)
{
    if (file != null)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension != ".xls" && fileExtension != ".xlsx")
        {
            ModelState.AddModelError("", "Please choose excel file to upload!");
        }
        else
        {
            //rename file when upload to server
            var fileName = DateTime.Now.ToShortTimeString().Replace(":", "") + fileExtension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels", fileName);
            var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from excel file fill DataTable
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Person person = new Person
                            {
                                PersonId = dt.Rows[i][0].ToString(),
                                FullName = dt.Rows[i][1].ToString(),
                                Address = dt.Rows[i][2].ToString()
                            };
                            _context.Persons.Add(person);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index)); 
            }
        }
    }
    return View();
}

    }
}

