namespace MyPortfolio.ViewModels.EditViewModel
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation; 

    public class EditSkillViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)]
        public int LevlPercent { get; set; } 
    }
}
