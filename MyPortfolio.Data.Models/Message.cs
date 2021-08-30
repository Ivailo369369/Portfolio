namespace MyPortfolio.Data.Models
{
    using MyPortfolio.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    using static Base.DataValidation; 

    public class Message : DeletableEntity
    {
        public int Id { get; set; } 

        [Required] 
        public string UserId { get; set; } 

        public User User { get; set; }

        [Required]
        public string Username { get; set; }

        [Required] 
        [MaxLength(MaxNameLenght)]
        public string FirstName { get; set; } 
        
        [Required]
        [MaxLength(MaxNameLenght)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress] 
        public string Email { get; set; } 

        [Required]
        public string TextMessage { get; set; }  
    }
}
