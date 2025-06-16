using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;

namespace CIS262AD_Final_Project.Pages.Exam
{
    public class DeleteModel : PageModel
    {
        private IExamAdapter _examAdapter;
        public int Id { get; set; }
        public DeleteModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        public bool IsSuccess = false;
        public void OnGet(int id = 0)
        {
            Id = id;
            if (id > 0)
            {
                bool isDelete = _examAdapter.DeleteExamById(id);
                if (isDelete)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
