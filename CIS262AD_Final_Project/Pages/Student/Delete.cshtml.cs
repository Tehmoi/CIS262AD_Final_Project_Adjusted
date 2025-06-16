using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;

namespace CIS262AD_Final_Project.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public int Id { get; set; }
        public DeleteModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        public bool IsSuccess = false;
        public void OnGet(int id = 0)
        {
            Id = id;
            if (id > 0)
            {
                bool isDelete = _studentAdapter.DeleteStudentById(id);
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
