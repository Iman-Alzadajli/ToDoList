using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {

        private ApplicationDbContext _context; //it help us to deal with db create delete update 
        public ToDoController(ApplicationDbContext context) 
        {
            _context = context;
        }


        public IActionResult Create(int CategoryId) // it should match router 
        {
            if (CategoryId == 0)
            {
                return RedirectToAction("Index", "Category"); //if user have no categoryid retun it back to category user should add cetgory first 
            }

            var task = new ToDo { CategoryId = CategoryId }; // create ob then return it to view 
            return View(task);
        }

        [HttpPost]
        public IActionResult Create(ToDo task)
        {
            if (task.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Please select a category");
            }

            if (ModelState.IsValid) // if eveything working 
            {
                _context.ToDos.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View(task); //return to add task page 
        }

        // is completed  
        public IActionResult ToggleStatus(int id)
        {
            var task = _context.ToDos.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            // change if completed or not 
            task.IsFinshed = !task.IsFinshed;
            _context.SaveChanges();


            return RedirectToAction("Index", "Category");
        }

        // dispaly update page 
        public IActionResult Edit(int id)
        {
            var task = _context.ToDos.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // update 
        [HttpPost]
        public IActionResult Edit(ToDo task)
        {
            if (ModelState.IsValid)
            {
                _context.ToDos.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View(task);
        }

        // dispaly delete page 
        public IActionResult Delete(int id)
        {
            var task = _context.ToDos.Find(id);
            if (task == null)
            {
                return NotFound(); // do you want to delete 
            }

            return View(task);
        }

        // delete 
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.ToDos.Find(id);
            if (task != null)
            {
                _context.ToDos.Remove(task);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Category");
        }

    }
}
