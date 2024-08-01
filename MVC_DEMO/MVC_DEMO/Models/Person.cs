using System.ComponentModel.DataAnnotations;

namespace MVC_DEMO.Models
{
    public class Person
    {
        [Display(Name = "Perosn Id")]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Person Name")]
        public string? Name { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
    }
}
