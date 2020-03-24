using System;
using static System.Console;
using System.Linq;
using static Exercise4.Misc.Database;
using Exercise4.Model;

namespace Exercise4.Controller
{
    class AddController
    {
        public void AddClass()
        {
            ViewController vc = new ViewController();
            //Ask for a student
            vc.ViewStudent();
            WriteLine("\tChoose student");
            Write("\tID: ");
            string s = ReadLine();
            //Ask for a course
            vc.ViewCourse();
            WriteLine("\tChoose course");
            Write("\tID: ");
            string c = ReadLine();
            //Add it to the database
            using (var data = new DbConnection())
            {
                CoursesWithStudents cws = new CoursesWithStudents()
                {
                    CourseID = c,
                    StudentID = s
                };
                data.CoursesWithStudents.Add(cws);
                data.SaveChanges();
                WriteLine("\tSuccess!");
            }
        }
        public void AddStudent()
        {
            //Ask for student information
            WriteLine("\t\tAdd a Student:");
            Write("\t\tFirstname:");
            string f = ReadLine();
            Write("\t\tLastname:");
            string l = ReadLine();
            //Small changes to make the data pretty
            f = FirstCharToUpper(f);
            l = FirstCharToUpper(l);
            string s = GenerateStudentID(f, l);
            //Add it to the database
            using (var data = new DbConnection())
            {
                Student student = new Student
                {
                    StudentID = s,
                    FirstName = f,
                    LastName = l
                };
                data.Student.Add(student);
                data.SaveChanges();
                WriteLine("\t\tSuccess!");
            }
        }
        public void AddCourse()
        {
            //Ask for courses information
            WriteLine("\t\tAdd a course:");
            Write("\t\tCourse name:");
            string name = Console.ReadLine();
            //Makes it pretty
            name = FirstCharToUpper(name);
            string id = GenerateStudentID("C", "C");
            using (var data = new DbConnection())
            {
                Course course = new Course
                {
                    CourseID = id,
                    CourseName = name
                };
                data.Course.Add(course);
                data.SaveChanges();
                WriteLine("\t\tSuccess!");
            }
        }
        public void GenerateFakeStudentsFast(string first, string last)
        {
            string f = FirstCharToUpper(first);
            string l = FirstCharToUpper(last);
            string s = GenerateStudentID(first, last);
            using (var data = new DbConnection())
            {
                Student student = new Student
                {
                    StudentID = s,
                    FirstName = f,
                    LastName = l
                };
                data.Student.Add(student);
                data.SaveChanges();
                WriteLine("\t\tSuccess!");
            }
        }

        /* Extra Methods */
        private string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                return input = "NULL";
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        private string GenerateStudentID(string firstname, string lastname)
        {
            Random r = new Random();
            string s = "null";
            using (var data = new DbConnection())
            {
                bool temp = true;
                while (temp)
                {
                    s = $"{firstname[0]}{lastname[0]}{r.Next(1,9)}{r.Next(1,9)}";
                    var checkID = (from student in data.Student
                                   where student.StudentID == s
                                   select student.StudentID).ToList();
                    if(checkID.Count == 0)
                    {
                        temp = false;
                    }
                }
            }
            return s;
        }



    }
    
}

