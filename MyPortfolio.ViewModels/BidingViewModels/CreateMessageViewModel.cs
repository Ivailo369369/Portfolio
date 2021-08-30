namespace MyPortfolio.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation;
    using static ValidationViewModel.Validation.Message;

    public class CreateMessageViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MaxLength(MaxNameLenght)]
        [Display(Name = First)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxNameLenght)]
        [Display(Name = Last)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = EmailAddress)] 
        public string Email { get; set; }

        [Required]
        [Display(Name = Text)] 
        public string TextMessage { get; set; }
    }
}
