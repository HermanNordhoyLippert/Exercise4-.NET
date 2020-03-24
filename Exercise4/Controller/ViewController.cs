using static System.Console;
using static Exercise4.Misc.Database;
using System.Linq;

namespace Exercise4.Controller
{
    internal class ViewController
    {
        public void ViewClass()
        {
            using (var data = new DbConnection())
            {
                WriteLine("\tClasses:");
                foreach (var course in View.View.courseList)
                {
                    string name = course.CourseName;
                    WriteLine($"\t\t{name}");
                    var result = (from cws in data.CoursesWithStudents
                                  join cour in data.Course on cws.CourseID equals cour.CourseID
                                  join student in data.Student on cws.StudentID equals student.StudentID
                                  where cour.CourseName == name
                                  select student.FirstName).ToList();
                    int i = 1;
                    foreach (var s in result)
                    {
                        if(s.ToString().Length > 0)
                        {
                            WriteLine($"\t\t\t{i++} - {s}");
                        }
                        else
                        {
                            WriteLine($"\t\t\tnull");
                        }
                    }
                }
            }
        }
        public void ViewStudent()
        {
            WriteLine("\tStudents:");
            WriteLine("\t\t[Student ID] - [Student name]");
            if (View.View.studentList.Count == 0)
            {
                WriteLine("\t\tNo students registered");
            }
            else
            {
                foreach (var i in View.View.studentList)
                {
                    WriteLine($"\t\t{i.ToString()}");
                }
            }
        }
        public void ViewCourse()
        {
            WriteLine("\tCourses:");
            WriteLine("\t\t[Course ID] - [Course Name]");
            if(View.View.courseList.Count == 0)
            {
                WriteLine("\t\tNo courses registered");
            }
            else
            {
                foreach (var i in View.View.courseList)
                {
                    WriteLine($"\t\t{i.ToString()}");
                }
            }
            
        }
        public void ViewAll()
        {
            using (var data = new DbConnection())
            {
                WriteLine($"\n\tStudents:{data.Student.Count()}\n\tCourses:{data.Course.Count()}\n\tClasses:{data.CoursesWithStudents.Count()}\n");
            }
            ViewClass();
            ViewStudent();
            ViewCourse();
        }
    }
}