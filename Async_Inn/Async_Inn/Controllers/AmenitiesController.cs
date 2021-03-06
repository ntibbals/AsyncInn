﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.Services;

namespace Async_Inn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenitiesManager _context; /// pulling in interface

        public AmenitiesController(IAmenitiesManager context) ///setting new interface as output for controller 
        {
            _context = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index(string searchString)
        {
            var amenity = await _context.GetAmenities();
            if (!String.IsNullOrEmpty(searchString))
            {
                amenity = amenity.Where(am => am.Name.Contains(searchString));
            }

            return View( amenity.ToList());
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var amenities = await _context.GetAmenities(id);
     
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    await _context.CreateAmenity(amenities);
                    return RedirectToAction(nameof(Index));
                }
                return View(amenities);
            }
            catch (Exception)
            {
                return Redirect("https://http.cat/500");

            }
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var amenity = await _context.GetAmenities(id);

            //var amenities = await _context.Amenities.FindAsync(id);
            //if (amenities == null)
            //{
            //    return NotFound();
            //}
            return View(amenity);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAmenity(amenities);

                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (AmenitiesExists(amenities.ID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                        throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var amenities = await _context.GetAmenities(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenities = await _context.GetAmenities(id);
            await _context.DeleteAmenity(amenities);
            return RedirectToAction(nameof(Index));
        }

        //private bool AmenitiesExists(int id)
        //{
        //    return _context.Amenities.Any(e => e.ID == id);
        //}
    }
}
