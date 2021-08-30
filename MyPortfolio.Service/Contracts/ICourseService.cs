namespace MyPortfolio.Service.Contracts
{
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.CourseViewModel;
    using MyPortfolio.ViewModels.EditViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks; 

    public interface ICourseService
    {
        Task AddCourseAsync(AddCourseViewModel model);

        Task<IEnumerable<IndexCourseViewModel>> GetAllCoursesAsync();

        Task<EditCourseViewModel> PrepareForEditingAsync(int id);  

        Task EditAsync(EditCourseViewModel model);

        Task RemoveAsync(int id);  
    }
}
