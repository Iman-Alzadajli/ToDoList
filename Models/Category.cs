using System.ComponentModel.DataAnnotations;
using ToDoList.Models.Enum;

namespace ToDoList.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}
