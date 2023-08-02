using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Student
    {
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int EnrollmentDate { get; set; }
    public List <StudentCourse> StudentCourses { get; set; }

}
}