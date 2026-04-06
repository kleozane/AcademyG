using GTest.Data;
using GTest.Models.Subject;
using GTest.Models.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GTest.Controllers
{
    public class SubjectController : Controller
    {
        private readonly TestContext _testContext;
        public SubjectController(TestContext testContext)
        {
            _testContext = testContext;
        }

        public async Task<IActionResult> Index()
        {
            var subjects = await _testContext.Subjects.ToListAsync();
            return View(subjects);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new SubjectForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectForCreation model)
        {
            var subject = new Subject
            {
                Name = model.Name,
                Category = model.Category
            };

            await _testContext.Subjects.AddAsync(subject);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var subject = await _testContext.Subjects.Where(s => s.Id == id).FirstOrDefaultAsync();

            var model = new SubjectForEdit
            {
                Name = subject.Name,
                Category = subject.Category
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubjectForEdit model)
        {
            var subject = new Subject
            {
                Id = model.Id,
                Name = model.Name,
                Category = model.Category
            };

            _testContext.Subjects.Update(subject);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _testContext.Subjects.Where(s => s.Id == id).FirstOrDefaultAsync();

            _testContext.Subjects.Remove(subject);
            await _testContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
