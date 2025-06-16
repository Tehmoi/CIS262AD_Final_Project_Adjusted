using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;

namespace CIS262AD_Final_Project.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        private ITeacherAdapter _teacherAdapter;
        public IndexModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        public IEnumerable<School.Dal.Teacher> Teachers { get; set; }
        public void OnGet()
        {
            Teachers = _teacherAdapter.GetAll();
        }
    }
}
