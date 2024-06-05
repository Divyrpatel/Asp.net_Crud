using Project.DataAccess;
using Project.DataAccess.Repository;
using Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project.Web.Controllers
{

    public class PersonController : Controller
    {
        private readonly  IPersonRepository _personRepo;
        private readonly ApplicationDbContext _context;

        public PersonController(IPersonRepository db, ApplicationDbContext context)
        {
            _personRepo = db;
            _context = context;
           
        }
     
        // GET: PersonController
        public  async Task<IActionResult> Index()
        {
            var persons = await   _personRepo.GetAll();

            var states = _context.States.ToList();
            var cities = _context.Cities.ToList();

            foreach (var temp in persons)
            {
                var state = states.Where(x => x.State_Id == temp.State_Id).ToList();
                var statename = state.First().Name;
                temp.StateName = statename;

                var city = cities.Where(x => x.City_Id == temp.City_Id).ToList();
                var cityname =  city.First().Name;             
                temp.CityName = cityname;
            }                      
            return View(persons);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public async Task<ActionResult> CreateOrEdit(int id = 0)
        {   
            if (id == 0)
            {
                //    var states = _context.States.ToList();
                var states = _context.States.ToList();
                ViewBag.stateselect = new SelectList(states, "State_Id", "Name");

                var cityList = _context.Cities.ToList();
                ViewBag.cityselect = new SelectList(cityList, "City_Id", "Name");

                return View(new Person());
            }
            else
            {
                var states = _context.States.ToList();
                ViewBag.stateselect = new SelectList(states, "State_Id", "Name");

                var cityList = _context.Cities.ToList();
                ViewBag.cityselect = new SelectList(cityList, "City_Id", "Name");

                Person person =  await _personRepo.GetById(id);
              
                if(person != null)
                {
                    return View(person);
                }

            }
            return View();
        }
        public JsonResult GetStates()
        {
            var states = _context.States.ToList();
            return new JsonResult(states);
        }

        public JsonResult GetCities(int id)
        {
            var cities = _context.Cities.Where(x => x.State_Id == id).OrderBy(x => x.Name).ToList();
            return new JsonResult(cities);
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOrEdit(Person model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(model.Person_Id == 0)
                    {
                        await _personRepo.Add(model);
                        TempData["success"] = "Record Created Successfully";
                    }
                    else
                    {
                        await  _personRepo.Update(model);
                        TempData["success"] = "Record Updated Successfully";
                    }
                }
                else
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            { 
              TempData["error"] = ex.Message;
            return View();
            }
        }

        //GET: PersonController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool status = await _personRepo.Delete(id);
                if (status == true)
                {
                    TempData["success"] = "Record Deleted Successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["success"] = "Record Not Deleted";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(Person model)
        //{
        //    try
        //    {
        //        bool status = await _personRepo.Delete(model.Person_Id);
        //        if (status == true)
        //        {
        //            TempData["success"] = "Record Deleted Successfully";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            TempData["success"] = "Record Not Deleted";
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch(Exception ex) 
        //    {
        //        TempData["error"] = ex.Message;
        //        return View();
        //    }
        //}
    }
}
