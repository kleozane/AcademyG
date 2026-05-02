using GTest.Data;
using GTest.Models.Classroom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GTest.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly TestContext _testContext;
        public ClassroomController(TestContext testContext)
        {
            _testContext = testContext;
        }

        public async Task<IActionResult> Index()
        {
            var classrooms = await _testContext.Classrooms.Include(c => c.HomeroomTeacher).ToListAsync();
            return View(classrooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var teachers = _testContext.Teachers.Where(t => t.ClassroomId == null).ToList();
            var model = new ClassroomForCreation
            {
                Teachers = teachers
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassroomForCreation model)
        {
            var classroom = new Classroom
            {
                Name = model.Name,
                HomeroomTeacherId = model.HomeroomTeacherId
            };
            
            await _testContext.Classrooms.AddAsync(classroom);
            await _testContext.SaveChangesAsync();

            var teacher = await _testContext.Teachers.Where(t => t.Id == model.HomeroomTeacherId).FirstOrDefaultAsync();
            teacher.ClassroomId = classroom.Id;
            _testContext.Teachers.Update(teacher);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var classroom = await _testContext.Classrooms.Where(c => c.Id == id).FirstOrDefaultAsync();
            var teachers = _testContext.Teachers.Where(t => t.ClassroomId == null || t.ClassroomId == id).ToList();

            var model = new ClassroomForEdit
            {
                Id = classroom?.Id ?? 0,
                Name = classroom?.Name,
                HomeroomTeacherId = classroom?.HomeroomTeacherId,
                Teachers = teachers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClassroomForEdit model)
        {
            var classroom = new Classroom
            {
                Id = model.Id,
                Name = model.Name,
                HomeroomTeacherId = model.HomeroomTeacherId
            };

            _testContext.Classrooms.Update(classroom);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var classroom = await _testContext.Classrooms.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (classroom != null)
            {
                _testContext.Classrooms.Remove(classroom);
                await _testContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }


        public async Task<JsonResult> GetStudents(int classroomId)
        {
            var students = await _testContext.Students
                .Where(s => s.ClassroomId == classroomId)
                .Select(s => new {
                    s.Id,
                    s.FirstName,
                    s.LastName,
                    s.SchoolYear,
                    BirthDate = s.BirthDate.ToString("dd-MM-yyyy")
                })
                .ToListAsync();

            return Json(students);
        }
    }
}