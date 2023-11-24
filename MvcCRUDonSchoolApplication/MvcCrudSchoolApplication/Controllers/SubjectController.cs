using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalMvcCrudSchool.Models;
using prolib;

namespace FinalMvcCrudSchool.Controllers
{
    public class SubjectController : Controller
    {
        prolib.MvcCrudSchoolEntities db = new prolib.MvcCrudSchoolEntities();
        public ActionResult Read()
        {
            List<Subject> listTo = db.Subjects.ToList();
            List<SubjectModel> smodel = new List<SubjectModel>();
            foreach (var item in listTo)
            {
                SubjectModel model = new SubjectModel();
                model.SubjectCode = item.SubjectCode;
                model.SubjectName = item.SubjectName;
                model.TeacherName = item.TeacherName;
                smodel.Add(model);
            }
            return View(smodel);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SubjectModel model = new SubjectModel();
                //model.Custid=Convert.ToInt32(collection["Custid"]);
                model.SubjectCode = Convert.ToInt32(collection["SubjectCode"]);
                model.SubjectName = collection["SubjectName"].ToString();
                model.TeacherName = collection["TeacherName"].ToString();

                Subject s = new Subject();
                s.SubjectCode = model.SubjectCode;
                s.SubjectName = model.SubjectName;
                s.TeacherName = model.TeacherName;
                db.Subjects.Add(s);
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int id)
        {
            Subject s = db.Subjects.Find(id);
            SubjectModel m = new SubjectModel();
            m.SubjectCode = s.SubjectCode;
            m.SubjectName = s.SubjectName;
            m.TeacherName = s.TeacherName;
            return View(m);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Subject s = db.Subjects.Find(id);
                s.SubjectCode = Convert.ToInt32(collection["SubjectCode"]);
                s.SubjectName = collection["SubjectName"].ToString();
                s.TeacherName = collection["TeacherName"].ToString();

                db.SaveChanges();
                return RedirectToAction("Read");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int id)
        {
            Subject s = db.Subjects.Find(id);
            SubjectModel m = new SubjectModel();
            m.SubjectCode = s.SubjectCode;
            m.SubjectName = s.SubjectName;
            m.TeacherName = s.TeacherName;

            return View(m);

        }

        // POST: Subjects/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Subject s = db.Subjects.Find(id);
                db.Subjects.Remove(s);

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
