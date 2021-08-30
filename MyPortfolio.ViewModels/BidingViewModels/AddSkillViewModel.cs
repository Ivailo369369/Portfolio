namespace MyPortfolio.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModel.Validation;
    using static ValidationViewModel.Validation.Skill;

    public class AddSkillViewModel
    {

        [Required(ErrorMessage = RequaredField)]
        [MaxLength(MaxNameLenght)]
        [Display(Name = DisplayName)] 
        public string Name { get; set; }

        [Required(ErrorMessage = RequaredField)] 
        [Display(Name = LevelName)]
        public int Level { get; set; } 
    }
}
