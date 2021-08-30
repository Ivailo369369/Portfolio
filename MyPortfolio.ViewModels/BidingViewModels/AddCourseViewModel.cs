namespace MyPortfolio.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations; 

    using static ValidationViewModel.Validation;
    using static ValidationViewModel.Validation.Course;

    public class AddCourseViewModel
    {
        [Required(ErrorMessage = RequaredField)] 
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)] 
        [Display(Name = DisplayName)] 
        public string Name { get; set; } 

        [Display(Name = CertificateImage)]
        [Required(ErrorMessage = RequaredField)] 
        public string Certificate { get; set; } 
    }
}
