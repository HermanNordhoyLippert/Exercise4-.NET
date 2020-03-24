using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System;
using Exercise4.Model;
using Exercise4.Misc;
using Exercise4.Controller;
using static Exercise4.Misc.Database;

namespace Exercise4.Misc
{
    public class NewObjects
    {
        // Data already in database. This code will fail, just for display purposes
        public static void CreateObjects()
        {
            using (var data = new DbConnection())
            {
                var student1 = new Student
                {
                    StudentID = "TEST",
                    FirstName = "Herman",
                    LastName = "Lippert"
                };

                var student2 = new Student
                {
                    StudentID = "TEST",
                    FirstName = "Maria",
                    LastName = "Skancke"
                };

                var course1 = new Course
                {
                    CourseID = "TEST",
                    CourseName = ".NET"
                };

                var course2 = new Course
                {
                    CourseID = "TEST",
                    CourseName = "OOP"
                };

                var sAndc1 = new CoursesWithStudents
                {
                    StudentID = student1.StudentID,
                    CourseID = course1.CourseID
                };

                var sAndc2 = new CoursesWithStudents
                {
                    StudentID = student2.StudentID,
                    CourseID = course2.CourseID
                };


                data.Student.Add(student1);
                data.Student.Add(student2);
                //data.Course.Add(course1);
                //data.Course.Add(course2);
                data.CoursesWithStudents.Add(sAndc1);
                data.CoursesWithStudents.Add(sAndc2);
                

                data.SaveChanges();
            }
        }

        

    }
}
