
namespace School.Dal
{
    public interface IExamAdapter
    {
        bool DeleteExamById(int id);
        IEnumerable<Exam> GetAll();
        Exam GetById(int id);
        bool InsertExam(Exam exam);
        bool UpdateExam(Exam exam);
    }
}