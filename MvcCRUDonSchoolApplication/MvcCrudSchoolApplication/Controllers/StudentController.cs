using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalMvcCrudSchool.Models;
using prolib;

namespace FinalMvcCrudSchool.Controllers
{

    public class StudentController : Controller
    {
        prolib.MvcCrudSchoolEntities db = new prolib.MvcCrudSchoolEntities();
        
        public ActionResult Read()
        {
            List<Student> listTo = db.Students.ToList();
           List<StudentModel> smodel = new List<StudentModel>();
            foreach (var item in listTo)
            {
                StudentModel model = new StudentModel();
                model.StudentRollNo = item.StudentRollNo;
                model.StudentName = item.StudentName;
                model.ClassId = (int)item.ClassId;
                model.SubjectCode = (int)item.SubjectCode;
                model.Gender = item.Gender;
                smodel.Add(model);
            }
            return View(smodel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
                StudentModel m = new StudentModel();
                m.StudentRollNo = Convert.ToInt32(collection["StudentRollNo"]);
                m.StudentName = collection["StudentName"].ToString();
                m.ClassId = Convert.ToInt32(collection["ClassId"]);
                m.SubjectCode = Convert.ToInt32(collection["SubjectCode"]);
                m.Gender = collection["Gender"].ToString();

                Student s = new Student();
                s.StudentRollNo = Convert.ToInt32(m.StudentRollNo);
                s.StudentName = m.StudentName;
                s.ClassId = Convert.ToInt32(m.ClassId);
                s.SubjectCode = (Convert.ToInt32(m.SubjectCode));
                s.Gender = m.Gender;
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Read");
            }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student s = db.Students.Find(id);
            StudentModel m = new StudentModel();
            m.StudentRollNo = s.StudentRollNo;
            m.StudentName = s.StudentName;
            m.ClassId = Convert.ToInt32(s.ClassId);
            m.SubjectCode = Convert.ToInt32(s.SubjectCode);
            m.Gender = s.Gender;
            return View(m);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Student s = db.Students.Find(id);
                s.StudentRollNo = Convert.ToInt32(collection["StudentRollNo"]);
                s.StudentName = collection["StudentName"].ToString();
                s.ClassId = Convert.ToInt32(collection["ClassId"]);
                s.SubjectCode = Convert.ToInt32(collection["SubjectCode"]);
               s.Gender = collection["Gender"].ToString();

                db.SaveChanges();
                return RedirectToAction("Read");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            
            Student s =db.Students.Find(id);
            StudentModel m = new StudentModel();
            m.StudentRollNo = s.StudentRollNo;
            m.StudentName = s.StudentName;
            m.ClassId = Convert.ToInt32(s.ClassId);
            m.SubjectCode =Convert.ToInt32( s.SubjectCode);
            m.Gender = s.Gender;
            return View(m);
            
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Student s = db.Students.Find(id);
                db.Students.Remove(s);

                db.SaveChanges();

                return RedirectToAction("Read");
            }
            catch
            {
                return View();
            }
        }
    }
}
