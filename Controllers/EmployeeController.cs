using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeTask.Models;
using System.IO;
using EmployeeTask.BusinessLogic;

namespace EmployeeTask.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeTaskDbEntities db;
        ExtraLogic ebl;
        public EmployeeController()
        {
            db = new EmployeeTaskDbEntities();
            ebl = new ExtraLogic();
        }
            

        public ActionResult Register()
        {
            string code = ebl.NextEmployeeCode();
            tblemployee e = new tblemployee() { Employee_Code = code };            

            return View(e);
        }

        [HttpPost]
        public ActionResult Resister(tblemployee e, HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                string imgname = e.Emp_Name + Path.GetExtension(photo.FileName);
                string imgpath = Server.MapPath("~/Profile Photo/" + imgname);
                photo.SaveAs(imgpath);
                e.Profile_Photo = imgname;
            }
            string password = ebl.GeneratePassword(10);
            e.password = password;
            db.tblemployees.Add(e);
            db.SaveChanges();
            string msg = "<h2>Dear " + e.Emp_Name + "</h2>,<p>your Account has been created successfully</p><p> You Can Access Your Account By Following Creadential.</p><p> Employee Code:<b> " + e.Employee_Code + "</b></br> Password:<b> " + e.password + "</b> <br/></p><p><br/><br/><br/><br/><br/><br/><h4>Thanks & Regards</h4><h4>Rutik Magar</h4></p>";
            string subject = "Employee Account Registration";
            ExtraLogic.Send_Email(e.Email_Address, msg, subject);
            ViewBag.msg = "your Account has been created successfully,You Can Access You Mail For Frither Process";
            ModelState.Clear();
            string code = ebl.NextEmployeeCode();
            tblemployee em = new tblemployee() { Employee_Code = code };
            return View(em);

        }
        public ActionResult login()
        {
            return View();
        }
    }
}