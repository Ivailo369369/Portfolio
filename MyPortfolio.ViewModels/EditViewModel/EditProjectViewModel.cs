namespace MyPortfolio.ViewModels.EditViewModel
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation;

    public class EditProjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Image { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Technologies { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Responsibilities { get; set; }

        public string SourceCode { get; set; }

        public string LiveOn { get; set; }
    }
}
