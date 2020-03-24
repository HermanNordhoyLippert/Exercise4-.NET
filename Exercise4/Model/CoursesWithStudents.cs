using System.ComponentModel.DataAnnotations;

namespace Exercise4
{
    internal class CoursesWithStudents
    {
        public string CourseID { get; set; }
        [Key]
        public string StudentID { get; set; }
    }
}