using FinalMvcCrudSchool.Models;
using prolib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalMvcCrudSchool.Controllers
{
    public class ClassController : Controller
    {
        prolib.MvcCrudSchoolEntities db = new prolib.MvcCrudSchoolEntities();

        public ActionResult Read
            ()
        {
            List<Class> listTo = db.Classes.ToList();
            List<ClassModel> smodel = new List<ClassModel>();
            foreach (var item in listTo)
            {
                ClassModel model = new ClassModel();
                model.ClassId = item.ClassId;
                model.ClassFloor = item.ClassFloor;

                smodel.Add(model);
            }
            return View(smodel);

        }

        // GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                SubjectModel model = new SubjectModel();
                ClassModel m = new ClassModel();
                m.ClassId = Convert.ToInt32(collection["CLassId"]);
                m.ClassFloor = collection["ClassFloor"].ToString();

                Class c = new Class();
                c.ClassId = m.ClassId;
                c.ClassFloor = m.ClassFloor;
                db.Classes.Add(c);
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            Class c = db.Classes.Find(id);
            ClassModel m = new ClassModel();
            m.ClassId = c.ClassId;
            m.ClassFloor = c.ClassFloor;
            return View(m);

        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Class c = db.Classes.Find(id);
                c.ClassId = Convert.ToInt32(collection["ClassId"]);
                c.ClassFloor = collection["ClassFloor"].ToString();


                db.SaveChanges();
                return RedirectToAction("Read");

            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int id)
        {
            Class c = db.Classes.Find(id);
            ClassModel m = new ClassModel();
            m.ClassId = c.ClassId;
            m.ClassFloor = c.ClassFloor;
            return View(m);
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Class c = db.Classes.Find(id);
                db.Classes.Remove(c);

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
