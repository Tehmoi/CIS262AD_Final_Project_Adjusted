﻿using Dapper;
using SQLitePCL;


namespace School.Dal
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
