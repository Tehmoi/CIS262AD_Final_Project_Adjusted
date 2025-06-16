using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CIS262AD_Final_Project.Pages.Exam
{
    public class EditModel : PageModel
    {
        private IExamAdapter _examAdapter;
        public EditModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        [BindProperty]
        [Required]
        [DisplayName("Student ID")]
        public int StudentId { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Score")]
        public int Score { get; set; }
        public int ExamId { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsSuccessUpdate { get; set; }
        public bool ErrorDetec { get; set; }

        public void OnGet(int id = 0)
        {
            Console.WriteLine("this is the ID on get: " + ExamId);
            if (id != 0)
            {
                School.Dal.Exam exam = _examAdapter.GetById(id);
                if (exam != null)
                {
                    StudentId = exam.StudentId;
                    Score = exam.Score;

                    ExamId = exam.ExamId;
                }
            }
            Console.WriteLine("this is the ID after get: " + ExamId);
        }
        public void OnPost(int id = 0)
        {
            Console.WriteLine("this is the ID after POST: " + ExamId);
            if (ModelState.IsValid)/*StudentId != null && Score != null &&  && BusinessName != null && BusinessTypes != null*/
            {
                if (id != 0)
                {
                    School.Dal.Exam examData = _examAdapter.GetById(id); // should bring the current information to variables.
                    if (examData != null)//function should be used to do its job and that alone, outside of the onGet method
                    {
                        ExamId = examData.ExamId;
                    }//solution grabs correct ID but does not post the data

                }



                School.Dal.Exam exam = new School.Dal.Exam();
                exam.StudentId = StudentId;
                exam.Score = Score;

                //Console.WriteLine("grabbed examId: " + ExamId + " Email is:" + Email + " Previouse Email is, " + exam.Email);
                if (ExamId > 0)
                {
                    Console.WriteLine(ExamId + " updated");
                    exam.ExamId = ExamId;


                    bool isUpdate = _examAdapter.UpdateExam(exam);
                    if (isUpdate)
                    {
                        IsSuccessUpdate = true;
                        Console.WriteLine("grabbed Id After True success: " + " ExamID: " + ExamId);

                    }
                    else
                    {
                        IsSuccessUpdate = false;
                    }

                }
                else
                {
                    Console.WriteLine("Inserted new ID: " + ExamId);
                    bool isCreate = _examAdapter.InsertExam(exam);
                    if (isCreate)
                    {
                        IsSuccess = true;
                    }
                    else
                    {
                        IsSuccess = false;
                    }

                }
            }
            else
            {
                //SetupBusinessTypes();
                IsSuccess = false;
                ErrorDetec = true;
            }
        }
    }
}
