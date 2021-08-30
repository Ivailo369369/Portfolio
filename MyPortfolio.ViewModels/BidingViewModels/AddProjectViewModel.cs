namespace MyPortfolio.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation;
    using static ValidationViewModel.Validation.Project;

    public class AddProjectViewModel
    {
        [Required(ErrorMessage = RequaredField)]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        [Display(Name = DisplayName)] 
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [Display(Name = ImageProject)]
        public string Image { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [Display(Name = ProjectDescription)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [Display(Name = TehnologiesUsed)]
        public string Technologies { get; set; }

        [Required(ErrorMessage = RequaredField)]
        [Display(Name = ResponsibilitiesDisplayName)]
        public string Responsibilities { get; set; }

        [Display(Name = Code)]
        public string SourceCode { get; set; }

        [Display(Name = Live)]
        public string LiveOn { get; set; }
    }
}
