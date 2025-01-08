
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeChallenge8_2
{
    public class MovieController : Controller
    {
        private MovieDbContext _context = new MovieDbContext();

        // List All Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // Create Movie
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // Edit Movie
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(movie).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }