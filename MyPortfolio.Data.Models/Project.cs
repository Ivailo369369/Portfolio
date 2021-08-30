namespace MyPortfolio.Data.Models
{
    using MyPortfolio.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    using static Base.DataValidation;

    public class Project : DeletableEntity 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLenght)] 
        public string Name { get; set; } 

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Technologies { get; set; }

        [Required]
        public string Responsibilities { get; set; } 

        public string SourceCode { get; set; }

        public string LiveOn { get; set; }
    }
}
