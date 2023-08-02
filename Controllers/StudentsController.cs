using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityRegistrar.Controllers
{

public class StudentsController : Controller 
{
    private readonly UniversityRegistrarContext _db;
    public StudentsController(UniversityRegistrarContext db)
    {
        _db = db;
    }
    
    public ActionResult Index()
    {
        List<Student> model = _db.Students.ToList();
        return View(model);
    }
    public ActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
    public ActionResult Create (Student student)
    {
        _db.Students.Add(student);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
        return View(thisStudent);

    }
    [HttpPost]

    public ActionResult Edit(Student student)
    {
        _db.Students.Update(student);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
        Student thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
        ViewBag.CourseId = new SelectList(_db.Students, "CourseId", "StudentName");
        return View(thisStudent);
    }

   public ActionResult Details (int id)
    {
        Student thisStudent = _db.Students.Include(s => s.StudentCourses).ThenInclude(s => s.Student).FirstOrDefault(s => s.StudentId == id);
        return View(thisStudent);
        }
    }
}

