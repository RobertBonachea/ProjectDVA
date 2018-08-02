using Domain.Entities;
using Services.AddressService;
using Services.PersonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IAddressService _addressService;

        public PersonController(IPersonService personService, IAddressService addressService)
        {
            _personService = personService;
            _addressService = addressService;
        }

        // GET: Person
        public ActionResult Index()
        {
            return View(_personService.GetPeople());
        }


        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return PartialView("_Details", _personService.GetPersonById(id));
            
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // save model to database
                    _personService.Insert(model);
                }
                else
                {
                    // Errors are preventing model from saving
                    return View(model);
                }

                // return to list
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var result = ex.Message;
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_personService.GetPersonById(id));
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(Person model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personService.UpdatePerson(model);
                    _addressService.UpdateAddress(model.Address);
                }
                else
                {
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var result = ex.Message;
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", _personService.GetPersonById(id));
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            if (id == 0)
            {
                return Json(new { success = true, url = "/Person/Index" }, JsonRequestBehavior.AllowGet);
            }
            
            // load object
            var person = _personService.GetPersonById(id);
            try
            {
                                
                _personService.DeletePerson(person);
                return Json(new { success = true, url = "/Person/Index" }, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                
                return PartialView("_Delete", person);
            }
        }
    }
}
