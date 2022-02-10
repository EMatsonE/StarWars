using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using StarWars.Models;

namespace StarWars.Controllers
{
    public class PlanetController : Controller
    {
        List<Planet> _planetCollection;
        // GET: PlanetController
        [HttpGet]
        public ActionResult Index()
        {
            string apiUri = "https://swapi.dev/api/planets/";
            var apiTask = apiUri.GetJsonAsync<Results>();
            apiTask.Wait();
            _planetCollection = apiTask.Result.results;
            apiTask.Wait();

            _planetCollection = apiTask.Result.results;

            return View(_planetCollection);
        }

        [HttpPost]
        public ActionResult Index(string pageNumber = "1")
        {

            string apiUri = $"https://swapi.dev/api/planets/?page={pageNumber}";
            var apiTask = apiUri.GetJsonAsync<Results>();
            apiTask.Wait();
            _planetCollection = apiTask.Result.results;

            return View(_planetCollection);        
        }
        // GET: PlanetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlanetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PlanetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanetController/Edit/5
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

        // GET: PlanetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanetController/Delete/5
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
