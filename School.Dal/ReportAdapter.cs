using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace School.Dal
{
    public class ReportAdapter : IReportAdapter
    {
        private string connectionString = @"Data Source=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\PublicAssemblies\SQLite\School.db";
        public IEnumerable<Report> GetGrades()
        {
            string sql = /*@"SELECT Score WHEN Score < 90 then 'D'FROM Exam";*/
                @"SELECT  Score,  CASE  WHEN Score >= 90 THEN 'A'
                                        WHEN Score >= 80 THEN 'B'
                                        WHEN Score >= 70 THEN 'C'
                                        WHEN Score >= 60 THEN 'D'
                                        WHEN Score < 60 THEN 'F'
                                 END AS Grade

                                 FROM Exam GROUP BY StudentId 
                                            ORDER BY Score DESC";
                                 //orderby statement is testing. may delete if needed.

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.Query<Report>(sql);
            }
        }
        public string getLetter(int score) 
        { // Does not Display F's
            //hmmmmm. Code refuses to accept failures...
            //^issue fixed. question now is, why does it require the < and not > code still works fine
            string Grade = "F";
            if (score <= 90)
            {
                 Grade = "A";
                return Grade;
            }
            else if (score <= 80)
            {
                 Grade = "B";
                return Grade;
            }
            else if (score <= 70)
            {
                 Grade = "C";
                return Grade;
            }
            else if (score <= 60)
            {
                 Grade = "D";
                return Grade;
            }
            else if (score < 60) // this code is skipped. # solved months ago. no clue what changed.
            {
                Grade = "F";
                return Grade;
            }
            else {return Grade; }
            
        }
    }
}
