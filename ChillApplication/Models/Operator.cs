using System.ComponentModel.DataAnnotations;

namespace ChillApplication.Models
{
    public class Operator
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        private string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required] 
        public bool IsAdmin { get;}
        [Required]
        private string Password { get; set; }

        
    }
}
