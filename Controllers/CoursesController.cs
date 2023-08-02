using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;


namespace UniversityRegistrar.Controllers
{

public class CoursesController : Controller 
{
    private readonly UniversityRegistrarContext _db;
    public CoursesController(UniversityRegistrarContext db)
    {
        _db = db;
    }
    public ActionResult Index()
    {
        List<Course> model = _db.Courses.ToList();
        
        return View(model);
    }
    
    public ActionResult Create ()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create (Course course)
    {
        _db.Courses.Add(course);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
        return View(thisCourse);
    }

    [HttpPost]

    public ActionResult Edit(Course course)
    {
        _db.Courses.Update(course);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details (int id)
    {
        Course thisCourse = _db.Courses.Include(c => c.StudentCourses).ThenInclude(s => s.Student).FirstOrDefault(s => s.CourseId == id);
        return View(thisCourse);
    }


 }   
}

