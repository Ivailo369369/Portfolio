namespace MyPortfolio.ViewModels.EditViewModel
{
    using System;

    public class EditExperienceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Responsibilities { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
