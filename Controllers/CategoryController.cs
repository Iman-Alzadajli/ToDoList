using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            // جلب الكاتيجوريز مع المهام المرتبطة بهم
            var categories = _context.Categories
                .Include(c => c.ToDos)
                .ToList();

            return View(categories);
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }



        // delete category 
        public IActionResult DeleteDirect(int id)
        {
            var category = _context.Categories
                .Include(c => c.ToDos)
                .FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                // حذف جميع المهام المرتبطة بالفئة أولاً
                _context.ToDos.RemoveRange(category.ToDos);

                // ثم حذف الفئة نفسها
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }




    }

}
