using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;

namespace CIS262AD_Final_Project.Pages.Exam
{
    public class IndexModel : PageModel
    {
        private IExamAdapter _examAdapter;
        public IndexModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        public IEnumerable<School.Dal.Exam> Exams { get; set; }
        public void OnGet()
        {
            Exams = _examAdapter.GetAll();
        }
    }
}
