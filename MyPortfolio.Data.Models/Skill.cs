namespace MyPortfolio.Data.Models
{
    using MyPortfolio.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    using static Base.DataValidation;

    public class Skill : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLenght)]
        public string Name { get; set; }

        [Required]
        public int LevlPercent { get; set; }
    }
}
