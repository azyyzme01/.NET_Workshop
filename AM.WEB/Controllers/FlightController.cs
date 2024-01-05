using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.WEB.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight sf;
        IServicePlane sp;

        public FlightController(IServiceFlight sf, IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }



        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(sf.GetAll().OrderByDescending(p=>p.FlightDate));
                    return View(sf.GetMany(p => p.FlightDate.Date.Equals(dateDepart)));
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create

        public ActionResult Create()
        {
            ViewBag.PlaneList = new SelectList(sp.GetAll(), "PlaneId", "Capacity");//tjiblk la liste des avions besh namlolha affichacge fl create ta3 flight
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            try
            {
                sf.Add(flight);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
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

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
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
