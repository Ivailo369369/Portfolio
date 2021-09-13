namespace MyPortfolio.ViewModels.EditViewModel
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation; 

    public class EditCourseViewModel
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = RequaredField)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Certificate { get; set; }
    }
}
