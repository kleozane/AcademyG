using GTest.Data;
using GTest.Models.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GTest.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TestContext _testContext;
        public TeacherController(TestContext testContext)
        {
            _testContext = testContext;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _testContext.Teachers.ToListAsync();
            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TeacherForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherForCreation model)
        {
            var teacher = new Teacher
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = DateTime.ParseExact(model.BirthDate, "MM/dd/yyyy", null)
            };

            await _testContext.Teachers.AddAsync(teacher);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var teacher = await _testContext.Teachers.Where(s => s.Id == id).FirstOrDefaultAsync();

            var model = new TeacherForEdit
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                BirthDate = teacher.BirthDate.ToString("dd/MM/yyyy")
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TeacherForEdit model)
        {
            var teacher = new Teacher
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = DateTime.ParseExact(model.BirthDate, "MM/dd/yyyy", null)
            };

            _testContext.Teachers.Update(teacher);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _testContext.Teachers.Where(s => s.Id == id).FirstOrDefaultAsync();

            _testContext.Teachers.Remove(teacher);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
