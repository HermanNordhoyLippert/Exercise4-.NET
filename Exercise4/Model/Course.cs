using System.ComponentModel.DataAnnotations;

namespace Exercise4
{
    public class Course
    {
        [Key]
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public override string ToString()
        {
            return $"{CourseID} - {CourseName}";
        }
    }
}
