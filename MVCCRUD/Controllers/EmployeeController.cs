using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCCRUD.Models;
using System.Data.Entity;

namespace MVCCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (EmployeeEntities ee = new EmployeeEntities())
            {
                List<EmpDetail> empList = ee.EmpDetails.ToList<EmpDetail>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);

            }

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new EmpDetail());
            }
            else
            {
                using (EmployeeEntities ee = new EmployeeEntities())
                    return View(ee.EmpDetails.Where(x => x.EmployeeID == id).FirstOrDefault<EmpDetail>());
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEdit(EmpDetail emp) 
        {
            using (EmployeeEntities ee = new EmployeeEntities())
            {
                if (emp.EmployeeID == 0)
                {
                    ee.EmpDetails.Add(emp);
                    ee.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    ee.Entry(emp).State = EntityState.Modified;
                    ee.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }

            }
            

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using(EmployeeEntities ee = new EmployeeEntities())
            {
                EmpDetail ed = ee.EmpDetails.Where(x => x.EmployeeID == id).FirstOrDefault<EmpDetail>();
                ee.EmpDetails.Remove(ed);
                ee.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

            }

        }



    }

    
}