using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace School.Dal
{
    public class TeacherAdapter : ITeacherAdapter
    {
        private string connectionString = @"Data Source=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\PublicAssemblies\SQLite\School.db";


        public IEnumerable<Teacher> GetAll()
        {
            string sql = "SELECT * FROM Teacher";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.Query<Teacher>(sql);
            }
        }

        public Teacher GetById(int id)
        {
            string sql = @"SELECT TeacherId, FirstName, LastName FROM Teacher 
            WHERE TeacherId = @TeacherId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.QueryFirst<Teacher>(sql, new { TeacherId = id });
            }
        }
        public bool InsertTeacher(Teacher teacher)
        {

            string sql = "INSERT INTO Teacher (FirstName, LastName) " +
                "VALUES (@FirstName, @LastName)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {

                int rowsAffected = connection.Execute(sql, teacher);
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

        public bool UpdateTeacher(Teacher teacher)
        {
            string sql = @"UPDATE Teacher SET TeacherId = @TeacherId, 
            FirstName = @FirstName, LastName = @LastName
            WHERE TeacherId = @TeacherId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, teacher);
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
        public bool DeleteTeacherById(int id)
        {
            string sql = "DELETE FROM Teacher WHERE TeacherId = @TeacherId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, new { TeacherId = id }); //foreign key failure when deleting 
                                                                                    //error occuring for manually inserted Foreign Key for InsertInvoice method
                                                                                    //NEW! error occurs on any row tied to the Teacher Table
                                                                                    // However TeacherId 100 can be updated because it does not conflict with the Invoice Table
                return true;

            }
        }
    }
}
