using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee> lstEmps = new List<Employee>();

            lstEmps.Add(new Employee { EmpNo = 1, Name = "Yash", Basic = 12345, DeptNo = 10 });
            lstEmps.Add(new Employee { EmpNo = 2, Name = "Lalit", Basic = 12345, DeptNo = 10 });
            lstEmps.Add(new Employee { EmpNo = 3, Name = "Saurabh", Basic = 12345, DeptNo = 10 });

            return View(lstEmps);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Vikram";
            obj.Basic = 99999;
            obj.DeptNo = 10;


            return View(obj);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
           
                return View();
            
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string EmpNo = collection["EmpNo"];
                string Name = collection["Name"];
                string Basic = collection["Basic"];
                string DeptNo = collection["DeptNo"];

               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
