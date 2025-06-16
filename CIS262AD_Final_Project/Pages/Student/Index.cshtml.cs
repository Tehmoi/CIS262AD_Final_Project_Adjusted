using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;

namespace CIS262AD_Final_Project.Pages.Student
{
    public class IndexModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public IndexModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        public IEnumerable<School.Dal.Student> Students { get; set; }
        public void OnGet()
        {
            Students = _studentAdapter.GetAll();
        }

    }
}
