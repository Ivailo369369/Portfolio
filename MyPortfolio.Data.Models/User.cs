namespace MyPortfolio.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using MyPortfolio.Data.Models.Base;
    using System;

    public class User : IdentityUser, IEntity
    {
        public DateTime CreatedOn { get; set; } 

        public DateTime? ModifiedOn { get; set; }
    }
}
