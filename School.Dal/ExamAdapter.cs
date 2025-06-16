using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace School.Dal
{
    public class ExamAdapter : IExamAdapter
    {
        private string connectionString = @"Data Source=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\PublicAssemblies\SQLite\School.db";
        public IEnumerable<Exam> GetAll()
        {
            string sql = "SELECT * FROM Exam";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.Query<Exam>(sql);
            }
        }
        public Exam GetById(int id)
        {
            string sql = @"SELECT ExamId, StudentId, Score FROM Exam 
            WHERE ExamId = @ExamId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.QueryFirst<Exam>(sql, new { ExamId = id });
            }
        }
        public bool InsertExam(Exam exam)
        {

            string sql = "INSERT INTO Exam (StudentId, Score) " +
                "VALUES (@StudentId, @Score)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {

                int rowsAffected = connection.Execute(sql, exam);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateExam(Exam exam)
        {
            string sql = @"UPDATE Exam SET ExamId = @ExamId, 
            StudentId = @StudentId, Score = @Score
            WHERE ExamId = @ExamId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, exam);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteExamById(int id)
        {
            string sql = "DELETE FROM Exam WHERE ExamId = @ExamId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, new { ExamId = id }); //foreign key failure when deleting 
                //error occuring for manually inserted Foreign Key for InsertInvoice method
                //NEW! error occurs on any row tied to the Student Table
                // However StudentId 100 can be updated because it does not conflict with the Invoice Table
                return true;

            }
        }
    }
}
