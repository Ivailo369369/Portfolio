namespace MyPortfolio.ViewModels.ValidationViewModel
{
    public class Validation
    {
        public const string RequaredField = "This field is requared";
        public const int MaxNameLenght = 64;
        public const int MinNameLenght = 4;

        public const string DisplayName = "Name"; 

        public class Course
        {
            public const string CertificateImage = "Certificate(Image/Link)"; 
        } 

        public class Education
        {
            public const string EducationDescription = "Description";
            public const string CertificateImage = "Certificate(Image/Link)";
        } 

        public class Experience
        {
            public const string ExperienceDescription = "Description";
            public const string ResponsibilitiesDisplayName = "Responsibilities";   
        } 

        public class Language
        {
            public const string LanguageLevel = "Level";
        } 

        public class Project
        {
            public const string ProjectDescription = "Description";
            public const string ImageProject = "Image";
            public const string TehnologiesUsed = "Tehnologies";
            public const string ResponsibilitiesDisplayName = "Responsibilities";
            public const string Code = "SourceCode";
            public const string Live = "LiveOn"; 
        }

        public class Message
        {
            public const string EmailAddress = "Email";
            public const string First = "First Name";
            public const string Last = "Last Name";
            public const string Text = "Message"; 
        } 

        public class Skill
        {
            public const int MaxLevel = 100;
            public const string LevelName = "Level";
        }
    }
}
