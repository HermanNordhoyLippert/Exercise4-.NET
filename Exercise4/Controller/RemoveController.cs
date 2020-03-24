using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise4.Controller;
using static Exercise4.Misc.Database;

namespace Exercise4.Controller
{
    class RemoveController
    {
        public void RemoveStudent()
        {
            ViewController viewController = new ViewController();
            viewController.ViewStudent();
            Write($"\n\t\tType in studentID:");
            string id = Console.ReadLine();
            using (var data = new DbConnection())
            {
                var deleteQueryStudent = from s in data.Student
                        where s.StudentID == id
                        select s;

                var deleteQueryCoursesWithStudents = from s in data.CoursesWithStudents
                                     where s.StudentID == id
                                     select s;

                data.Student.RemoveRange(deleteQueryStudent);
                data.CoursesWithStudents.RemoveRange(deleteQueryCoursesWithStudents);
                data.SaveChanges();
                WriteLine("\t\tSuccess!");
            }
        }
        public void RemoveCourse()
        {
            ViewController viewController = new ViewController();
            viewController.ViewCourse();
            Write($"\t\tType in courseID:");
            string id = Console.ReadLine();

            using (var data = new DbConnection())
            {
                var deleteQueryCourse = from c in data.Course
                                         where c.CourseID == id
                                         select c;

                var deleteQueryCoursesWithStudents = from c in data.CoursesWithStudents
                                                     where c.CourseID == id
                                                     select c;

                data.Course.RemoveRange(deleteQueryCourse);
                data.CoursesWithStudents.RemoveRange(deleteQueryCoursesWithStudents);
                data.SaveChanges();
                WriteLine("\t\tSuccess!");
            }
        }
        public void RemoveStudentFromClass()
        {
            //TO DO
        }

    }
}
