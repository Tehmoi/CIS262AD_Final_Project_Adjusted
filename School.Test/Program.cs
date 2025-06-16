// See https://aka.ms/new-console-template for more 
using School.Dal;
using System.Linq;
using System.Text.Json;





Console.WriteLine("Create test data for each table???  y or n?");
string LoopCheck = Console.ReadLine();
bool testLoopCandD = true;

if (LoopCheck == "y" || LoopCheck == "Y")
{
    Console.WriteLine("\n" + "Adding to all three table.");//make this a method later.
    string StudentFnameEntry = "TestStudentFirst";
    string StudentLnameEntry = "TestStudentLast";
    Console.WriteLine("Studnet First Name: " + StudentFnameEntry);
    Console.WriteLine("Student Last Name: "+ StudentLnameEntry);
    Student student = new Student();
    student.FirstName = StudentFnameEntry;
    student.LastName = StudentLnameEntry;
    StudentAdapter studentAdapter1 = new StudentAdapter();
    studentAdapter1.InsertStudent(student);

    Console.WriteLine("\n" + "Adding to all three table.");//make this a method later.
    string TeacherFnameEntry = "TestTeacherFirst";
    string TeacherLnameEntry = "TestTeacherLast";
    Console.WriteLine("Teacher First Name: " + TeacherFnameEntry);
    Console.WriteLine("Teacher Last Name: " + TeacherLnameEntry);
    Teacher teacher = new Teacher();
    teacher.FirstName = TeacherFnameEntry;
    teacher.LastName = TeacherLnameEntry;
    TeacherAdapter teacherAdapter1 = new TeacherAdapter();
    teacherAdapter1.InsertTeacher(teacher);

    Console.WriteLine("\n" + "Adding to all three table.");//make this a method later.
    int StudentId = 1;
    int Score = 80;
    Console.WriteLine("Exam StudentId: " + StudentId);
    Console.WriteLine("Score: " + Score);
    Exam exam= new Exam();
    exam.StudentId = StudentId;
    exam.Score = Score;
    ExamAdapter examAdapter1 = new ExamAdapter();
    examAdapter1.InsertExam(exam);
}    

StudentAdapter studentAdapter = new StudentAdapter();
IEnumerable<Student> students = studentAdapter.GetAll();

TeacherAdapter teacherAdapter = new TeacherAdapter();
IEnumerable<Teacher> teachers = teacherAdapter.GetAll();

ExamAdapter examAdapter = new ExamAdapter();
IEnumerable<Exam> exams = examAdapter.GetAll();
Console.WriteLine("STUDENT TABLE");
foreach (Student student in students)
{
    Console.WriteLine($"StudentId: {student.StudentId} FirstName: {student.FirstName} LastName: " +
        $" {student.LastName}");

}
Console.WriteLine("\r \r");
Console.WriteLine("TEACHER TABLE");
foreach (Teacher teacher in teachers)
{
    Console.WriteLine($"TeacherId: {teacher.TeacherId} FirstName: {teacher.FirstName} LastName: " +
        $" {teacher.LastName}");

}
Console.WriteLine("\r \r");

Console.WriteLine("EXAM TABLE");
foreach (Exam exam in exams)
{
    Console.WriteLine($"ExamId: {exam.ExamId} FirstName: {exam.StudentId} LastName: " +
        $" {exam.Score}");

}