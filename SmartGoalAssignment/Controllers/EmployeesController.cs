using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Employees;
using DataAccess;
//using SmartGoalAssignment.Models;

namespace SmartGoalAssignment.Controllers
{

    public class EmployeesController : Controller
    {
        private IEmployeeRepository  EmployeeRepository;
        public EmployeesController()
        {
            AdventureWorks2014Entities db = new AdventureWorks2014Entities();

        EmployeeRepository = new EmployeeRepository(db);
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employer = EmployeeRepository.GetAllEmployees();
            //employer2 = (SmartGoalAssignment.Models.Employee)employer;
           return View(employer.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
           // Employee employee = db.Employees.Find(id);
           Employee employee = EmployeeRepository.GetDetailsByID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.AddEmployee(employee);
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            Employee employee = EmployeeRepository.GetDetailsByID(id);
            EmployeeRepository.UpdateEmployee(employee);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.UpdateEmployee(employee);
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            EmployeeRepository.DeleteEmployee(id);
            
            return View(id);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = EmployeeRepository.GetDetailsByID(id);
            EmployeeRepository.DeleteEmployee(id);
            EmployeeRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                EmployeeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
