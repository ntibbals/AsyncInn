using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;

namespace Async_Inn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public RoomAmenitiesController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: RoomAmenities
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenities).Include(r => r.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.AmenitiesID == id);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.Add(roomAmenities);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
                ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
                return View(roomAmenities);
            }
            catch (Exception)
            {
                return Redirect("https://http.cat/500");

            }
        }

        // GET: RoomAmenities/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var roomAmenities = await _context.RoomAmenities.FindAsync(id);
        //    if (roomAmenities == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
        //    ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
        //    return View(roomAmenities);
        //}

        // POST: RoomAmenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int amenID, int roomID, [Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        //{
        //    if (amenID != roomAmenities.AmenitiesID && roomID != roomAmenities.RoomID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(roomAmenities);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoomAmenitiesExists(roomAmenities.AmenitiesID, roomAmenities.RoomID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
        //    ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
        //    return View(roomAmenities);
        //}

        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int? amenitiesID, int? roomID)
        {
            if (amenitiesID == null || roomID == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(ro => ro.Amenities)
                .Include(ro => ro.Room)
                .FirstOrDefaultAsync(am => am.AmenitiesID == amenitiesID && am.RoomID == roomID);

            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }
        //public async Task<IActionResult> Delete(RoomAmenities roomAmenities)
        //{
        //    try
        //    {
        //        _context.Entry(roomAmenities).State = EntityState.Deleted;
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return RedirectToAction("Delete", new { am = roomAmenities.AmenitiesID, ro = roomAmenities.RoomID });
        //    }
        //}

        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int amenitiesID, int roomID)
        {
            var roomAmenities = _context.RoomAmenities
                .Include(ro => ro.Amenities)
                .Include(ro => ro.Room)
                .FirstOrDefault(am => am.AmenitiesID == amenitiesID && am.RoomID  == roomID);
            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenitiesExists(int amenitiesID, int roomID)
        {
            return _context.RoomAmenities.Any(am => am.AmenitiesID == amenitiesID && am.RoomID == roomID);
        }
    }
}
