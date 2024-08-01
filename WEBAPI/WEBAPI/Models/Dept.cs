using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Models
{
    [Table("Depts",Schema ="DeptSchema")]
    public class Dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptNo { get; set; }
        [Required]
        [MaxLength(50)]
        public string? DName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Location { get; set; }
    }
}
