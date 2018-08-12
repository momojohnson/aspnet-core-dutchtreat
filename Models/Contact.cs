using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Models
{
    public class Contact
    {
        [Required]
        [MinLength(5, ErrorMessage="Name must be at least 5 characters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage="Please enter a valid email address")]       
        public string Email { get; set; }   
        [Required]
        public string Subject { get; set; } 
        [Required]
        [MaxLength(1000, ErrorMessage="Message length must be a max of 1000 characters")]
        public string Message { get; set; } 
              
    }
}