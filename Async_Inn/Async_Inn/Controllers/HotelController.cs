using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;

namespace Async_Inn.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelManager _context;

        public HotelController(IHotelManager context)
        {
            _context = context;
        }


        // GET: Hotel
        public async Task<IActionResult> Index(string searchString)
        {
            var hotel = await _context.GetHotels();
            if (!String.IsNullOrEmpty(searchString))
            {
                hotel = hotel.Where(am => am.Name.Contains(searchString));
            }

            return View(hotel.ToList());
        }

        // GET: Hotel/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _context.GetHotels(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _context.CreateHotel(hotel);
                    return RedirectToAction(nameof(Index));
                }
                return View(hotel);
            }
            catch (Exception)
            {
                return Redirect("https://http.cat/500");

            }
        }

        // GET: Hotel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var hotel = await _context.GetHotels(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var hotel = await _context.GetHotels(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.GetHotels(id);
            await _context.DeleteHotel(hotel);
            return RedirectToAction(nameof(Index));
        }

        //private bool HotelExists(int id)
        //{
        //    return _context.Hotel.Any(e => e.ID == id);
        //}
    }
}
