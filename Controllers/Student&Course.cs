using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
public class Student
{
    public string studentName { get; set; }
    public int studentID { get; set; }
    public int studentAge { get; set; }
    public Student(string studentName, int studentID, int studentAge)
    {
        this.studentName = studentName;
        this.studentID = studentID;
        this.studentAge = studentAge;
    }
}

public class Course
{
    public string courseName { get; set; }
    public int courseNumber { get; set; }
    public int courseClassroomLocation { get; set; }
    public Course(string courseName, int courseNumber, int courseClassroomLocation)
    {
        this.courseName = courseName;
        this.courseNumber = courseNumber;
        this.courseClassroomLocation = courseClassroomLocation;
    }
}

//add a route to get students
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private static List<Student> students = new List<Student>
    {
        new Student("John Doe", 1, 20),

        new Student("Jane Smith", 2, 22),
        new Student("Sam Brown", 3, 19)
    };
    [HttpGet]
    public ActionResult<List<Student>> GetStudents()
    {
        return students;
    }
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Student> GetStudentById(int id)
    {
        var student = students.FirstOrDefault(s => s.studentID == id);
        if (student == null)
        {
            return NotFound();
        }
        return student;
    }
}