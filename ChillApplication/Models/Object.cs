using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChillApplication.Models
{
    public class Object
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public Issue Issue { get; set; }
        [Required]
        public float X1 { get; set; }
        [Required]
        public float Y1 { get; set; }
        [Required]
        public float X2 { get; set; }
        [Required]
        public float Y2 { get; set; }
        [Required]
        public Category Category { get; set; }


    }
}
