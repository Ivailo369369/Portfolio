namespace MyPortfolio.ViewModels.EditViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation; 

    public class EditExperienceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Responsibilities { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public DateTime End { get; set; }
    }
}
