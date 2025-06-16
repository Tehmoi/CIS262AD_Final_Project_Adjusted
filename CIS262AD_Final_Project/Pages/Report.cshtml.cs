using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Dal;

namespace CIS262AD_Final_Project.Pages
{
    public class ReportModel : PageModel
    {
        private IReportAdapter _reportAdapter;
        public ReportModel(IReportAdapter reportAdapter)
        {
            _reportAdapter = reportAdapter;
        }

        public IEnumerable<Report> ReportRows { get; set; }

        public void OnGet()
        {
            ReportRows = _reportAdapter.GetGrades();
        }
    }
}
