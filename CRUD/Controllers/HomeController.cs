using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.db.CRUDOperations;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        CRUDOperations operations = null;

        public HomeController()
        {
            operations = new CRUDOperations();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(CustomerModel obj)
        {
            if (ModelState.IsValid)
            {
                if (operations.Add(obj) > 0)
                {
                    ModelState.Clear();
                    ViewBag.isSuccess = "Data has been Added";
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            var result = operations.ReadAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var result = operations.Read(id);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = operations.Read(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel obj)
        {
            if (ModelState.IsValid)
            {
                operations.Edit(obj.id, obj);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            operations.Delete(id);
            return RedirectToAction("Index");
        }
    }
}