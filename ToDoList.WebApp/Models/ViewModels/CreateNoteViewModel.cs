using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class CreateNoteViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [MaxLength(255, ErrorMessage ="Maximum title length is 255.")]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Content")]
        [MaxLength(255, ErrorMessage ="Maximum length: 4096 characters.")]

        public string Text { get; set; }
    }
}
