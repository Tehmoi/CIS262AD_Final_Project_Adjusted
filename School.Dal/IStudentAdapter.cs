
namespace School.Dal
{
    public interface IStudentAdapter
    {
        bool DeleteStudentById(int id);
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        bool InsertStudent(Student student);
        bool UpdateStudent(Student student);
    }
}