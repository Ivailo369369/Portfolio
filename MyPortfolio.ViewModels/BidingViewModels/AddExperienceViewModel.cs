namespace MyPortfolio.ViewModels.BidingViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation;
    using static ValidationViewModel.Validation.Experience;

    public class AddExperienceViewModel
    {
        [Required(ErrorMessage = RequaredField)]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        [Display(Name = DisplayName)] 
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [Display(Name = ExperienceDescription)] 
        public string Description { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [Display(Name = ResponsibilitiesDisplayName)] 
        public string Responsibilities { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [DataType(DataType.Date)] 
        public DateTime End { get; set; }
    }
}
