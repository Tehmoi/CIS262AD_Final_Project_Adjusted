using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace School.Dal
{
    public class StudentAdapter : IStudentAdapter
    {
        private string connectionString = @"Data Source=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\PublicAssemblies\SQLite\School.db";
        public IEnumerable<Student> GetAll()
        {
            string sql = "SELECT * FROM Student";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.Query<Student>(sql);
            }
        }

        public Student GetById(int id)
        {
            string sql = @"SELECT StudentId, FirstName, LastName FROM Student 
            WHERE StudentId = @StudentId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.QueryFirst<Student>(sql, new { StudentId = id });
            }
        }
        public bool InsertStudent(Student student)
        {

            string sql = "INSERT INTO Student (FirstName, LastName) " +
                "VALUES (@FirstName, @LastName)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {

                int rowsAffected = connection.Execute(sql, student);
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

        public bool UpdateStudent(Student student)
        {
            string sql = @"UPDATE Student SET StudentId = @StudentId, 
            FirstName = @FirstName, LastName = @LastName
            WHERE StudentId = @StudentId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, student);
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
        public bool DeleteStudentById(int id)
        {
            string sql = "DELETE FROM Student WHERE StudentId = @StudentId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, new { StudentId = id }); 
                //foreign key failure when deleting 
                //error occuring for manually inserted Foreign Key for InsertInvoice method
                //NEW! error occurs on any row tied to the Student Table
                // However StudentId 100 can be updated because it does not conflict with the Invoice Table
                return true;

            }
        }
    }
}
