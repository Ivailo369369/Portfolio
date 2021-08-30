namespace MyPortfolio.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation; 

    public class AddHobieViewModel
    {
        [Required(ErrorMessage = RequaredField)]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        [Display(Name = DisplayName)] 
        public string Name { get; set; }
    }
}
