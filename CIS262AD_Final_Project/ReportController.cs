using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Dal;

namespace CIS262AD_Final_Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportAdapter _reportAdapter;
        public ReportController(IReportAdapter reportAdapter)
        {
            _reportAdapter = reportAdapter;
        }
    }
}
