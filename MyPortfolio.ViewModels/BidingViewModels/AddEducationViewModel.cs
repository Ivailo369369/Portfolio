namespace MyPortfolio.ViewModels.BidingViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations; 

    using static ValidationViewModel.Validation;
    using static ValidationViewModel.Validation.Education;

    public class AddEducationViewModel
    {
        [Required(ErrorMessage = RequaredField)]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        [Display(Name = DisplayName)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [Display(Name = EducationDescription)] 
        public string Description { get; set; }

        [Display(Name = CertificateImage)] 
        public string Certificate { get; set; }
    }
}
