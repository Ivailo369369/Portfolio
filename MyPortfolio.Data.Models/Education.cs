namespace MyPortfolio.Data.Models
{
    using MyPortfolio.Data.Models.Base;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Base.DataValidation; 

    public class Education : Entity 
    {
        public int Id { get; set; } 

        [Required]
        [MaxLength(MaxNameLenght)] 
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Required] 
        public string Description { get; set; }

        public string Certificate { get; set; } 
    }
}
