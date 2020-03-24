using System.ComponentModel.DataAnnotations;

namespace Exercise4.Model
{
    public class Student
    {

        [Key]
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{StudentID} - {FirstName} {LastName}";
        }

    }
}