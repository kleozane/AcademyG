using GTest.Data;
using GTest.Models.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GTest.Controllers
{
    public class StudentController : Controller
    {
        private readonly TestContext _testContext;
        public StudentController(TestContext testContext) 
        {
            _testContext = testContext;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _testContext.Students.Include(s => s.Classroom).ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new StudentForCreation();
            model.Classrooms = await _testContext.Classrooms.ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentForCreation model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SchoolYear = model.SchoolYear,
                ClassroomId = model.ClassroomId,
                BirthDate = DateTime.ParseExact(model.BirthDate, "MM/dd/yyyy", null)
            };

            await _testContext.Students.AddAsync(student);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _testContext.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
            var classrooms = await _testContext.Classrooms.ToListAsync();

            var model = new StudentForEdit
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                SchoolYear = student.SchoolYear,
                ClassroomId = student.ClassroomId,
                Classrooms = classrooms,
                BirthDate = student.BirthDate.ToString("dd/MM/yyyy")
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentForEdit model)
        {
            var student = new Student
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SchoolYear = model.SchoolYear,
                ClassroomId = model.ClassroomId,
                BirthDate = DateTime.ParseExact(model.BirthDate, "MM/dd/yyyy", null)
            };

            _testContext.Students.Update(student);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _testContext.Students.Where(s => s.Id == id).FirstOrDefaultAsync();

            _testContext.Students.Remove(student);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
