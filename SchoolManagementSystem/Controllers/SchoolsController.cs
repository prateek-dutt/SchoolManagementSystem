﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly ISchoolRepo _context;

        public SchoolsController(ISchoolRepo context)
        {
            _context = context;
        }

        // GET: Schools
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllSchoolsAsync());
        }

        //GET: Schools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var school = await _context.GetSchool((int)id);
                
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: Schools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolId,SchoolName,Address")] School school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveAllSync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: Schools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.GetSchool((int)id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        public async Task<IActionResult> TeacherDetails()
        {
            ViewBag.schools = await _context.GetAllSchoolsAsync();

            return View();


            
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("SchoolId,SchoolName,Address")] School school)
        //{
        //    if (id != school.SchoolId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(school);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SchoolExists(school.SchoolId))
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
        //    return View(school);
        //}

        // GET: Schools/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var school = await _context.Schools
        //        .FirstOrDefaultAsync(m => m.SchoolId == id);
        //    if (school == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(school);
        //}

        // POST: Schools/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var school = await _context.Schools.FindAsync(id);
        //    _context.Schools.Remove(school);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SchoolExists(int id)
        //{
        //    return _context.Schools.Any(e => e.SchoolId == id);
        //}
    }
}
