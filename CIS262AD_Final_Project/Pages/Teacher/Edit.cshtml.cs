using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CIS262AD_Final_Project.Pages.Teacher
{
    public class EditModel : PageModel
    {
        private ITeacherAdapter _teacherAdapter;
        public EditModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        [BindProperty]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int TeacherId { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsSuccessUpdate { get; set; }
        public bool ErrorDetec { get; set; }

        public void OnGet(int id = 0)
        {
            Console.WriteLine("this is the ID on get: " + TeacherId);
            if (id != 0)
            {
                School.Dal.Teacher teacher = _teacherAdapter.GetById(id);
                if (teacher != null)
                {
                    FirstName = teacher.FirstName;
                    LastName = teacher.LastName;

                    TeacherId = teacher.TeacherId;
                }
            }
            Console.WriteLine("this is the ID after get: " + TeacherId);
        }
        public void OnPost(int id = 0)
        {
            Console.WriteLine("this is the ID after POST: " + TeacherId);
            if (ModelState.IsValid)/*FirstName != null && LastName != null &&  && BusinessName != null && BusinessTypes != null*/
            {
                if (id != 0)
                {
                    School.Dal.Teacher teacherData = _teacherAdapter.GetById(id); // should bring the current information to variables.
                    if (teacherData != null)//function should be used to do its job and that alone, outside of the onGet method
                    {
                        TeacherId = teacherData.TeacherId;
                    }//solution grabs correct ID but does not post the data

                }



                School.Dal.Teacher teacher = new School.Dal.Teacher();
                teacher.FirstName = FirstName;
                teacher.LastName = LastName;

                //Console.WriteLine("grabbed teacherId: " + TeacherId + " Email is:" + Email + " Previouse Email is, " + teacher.Email);
                if (TeacherId > 0)
                {
                    Console.WriteLine(TeacherId + " updated");
                    teacher.TeacherId = TeacherId;


                    bool isUpdate = _teacherAdapter.UpdateTeacher(teacher);
                    if (isUpdate)
                    {
                        IsSuccessUpdate = true;
                        Console.WriteLine("grabbed Id After True success: " + " TeacherID: " + TeacherId);

                    }
                    else
                    {
                        IsSuccessUpdate = false;
                    }

                }
                else
                {
                    Console.WriteLine("Inserted new ID: " + TeacherId);
                    bool isCreate = _teacherAdapter.InsertTeacher(teacher);
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
