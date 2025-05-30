using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Models.Enum;

namespace ToDoList.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Cant be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Can not be Empty")]

        public string Description { get; set; }
        [Required(ErrorMessage = "can not be empty")]

        public Priority Priority { get; set; }

        [Required (ErrorMessage = "You Should choose")]
        public DateTime Deadline { get; set; }

        public bool IsFinshed { get; set; } = false;
        [ForeignKey("CategoryId")]

        public Category? Category { get; set; } // so it can just take the fk only and the obj can be null 
        public int CategoryId { get; set; }

        //constractor 


    }



}
