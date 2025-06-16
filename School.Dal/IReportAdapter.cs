
namespace School.Dal
{
    public interface IReportAdapter
    {
        IEnumerable<Report> GetGrades();
        public string getLetter(int score);
    }
}