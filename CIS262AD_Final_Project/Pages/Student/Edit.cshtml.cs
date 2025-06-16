using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace CIS262AD_Final_Project.Pages.Student
{
    public class EditModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public EditModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        [BindProperty]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int StudentId { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsSuccessUpdate { get; set; }
        public bool ErrorDetec { get; set; }

        public void OnGet(int id = 0)
        {
            Console.WriteLine("this is the ID on get: " + StudentId);
            if (id != 0)
            {
                School.Dal.Student student = _studentAdapter.GetById(id);
                if (student != null)
                {
                    FirstName = student.FirstName;
                    LastName = student.LastName;
                    
                    StudentId = student.StudentId;
                }
            }
            Console.WriteLine("this is the ID after get: " + StudentId);
        }
        public void OnPost(int id = 0)
        {
            Console.WriteLine("this is the ID after POST: " + StudentId);
            if (ModelState.IsValid)/*FirstName != null && LastName != null &&  && BusinessName != null && BusinessTypes != null*/
            {
                if (id != 0)
                {
                    School.Dal.Student studentData = _studentAdapter.GetById(id); // should bring the current information to variables.
                    if (studentData != null)//function should be used to do its job and that alone, outside of the onGet method
                    {
                        StudentId = studentData.StudentId;
                    }//solution grabs correct ID but does not post the data

                }



                School.Dal.Student student = new School.Dal.Student();
                student.FirstName = FirstName;
                student.LastName = LastName;
                student.StudentId = StudentId;
                
                if (StudentId > 0)
                {
                    Console.WriteLine(StudentId + " updated");
                    student.StudentId = StudentId;
                    

                    bool isUpdate = _studentAdapter.UpdateStudent(student);
                    if (isUpdate)
                    {
                        IsSuccessUpdate = true;
                        Console.WriteLine("grabbed Id After True success: " + " StudentID: " + StudentId);

                    }
                    else
                    {
                        IsSuccessUpdate = false;
                    }

                }
                else
                {
                    Console.WriteLine("Inserted new ID: " + StudentId);
                    bool isCreate = _studentAdapter.InsertStudent(student);
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
                IsSuccess = false;
                ErrorDetec = true;
            }
        }
    }
}
