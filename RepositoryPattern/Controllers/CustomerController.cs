using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPattern_ServiceInterfaces;
using Repository_Database;

namespace RepositoryPattern.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _CustomerService;
        
        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        //
        // GET: /Customer/
        public ActionResult Index()
        {            
            List<Customer> model = (List<Customer>)_CustomerService.SelectAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CustomerById(string id)
        {
            if (int.Parse(id) > 0)
            {
                Customer model = _CustomerService.SelectByID(id);
                if(model != null)
                {
                    return Json(model);
                }
            }            
            return HttpNotFound();
        }


        public ActionResult Insert(Customer obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.City.ToUpper() == "BANGALORE")
                {
                    _CustomerService.Insert(obj);
                }
                return Json(true);
            }
            else
                return Json("400");
        }

        public ActionResult Edit(string id)
        {
            Customer existing = _CustomerService.SelectByID(id);
            return View(existing);
        }


        public ActionResult ConfirmDelete(string id)
        {
            Customer existing = _CustomerService.SelectByID(id);
            return View(existing);
        }

        public ActionResult Delete(string id)
        {
            _CustomerService.Delete(id);            
            return View();
        }

    }
}