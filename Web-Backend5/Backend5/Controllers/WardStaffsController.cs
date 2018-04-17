using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend5.Data;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class WardStaffsController : Controller
    {
        private readonly ApplicationDbContext context;

        public WardStaffsController(ApplicationDbContext context)
        {
            this.context = context;    
        }

        // GET: WardStaffs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = context.WardStaffs.Include(w => w.Ward);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WardStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wardStaff = await context.WardStaffs
                .Include(w => w.Ward)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wardStaff == null)
            {
                return NotFound();
            }

            return View(wardStaff);
        }

        // GET: WardStaffs/Create
        public IActionResult Create()
        {
            ViewData["WardId"] = new SelectList(context.Wards, "Id", "Name");
            return View();
        }

        // POST: WardStaffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,WardId")] WardStaff wardStaff)
        {
            if (ModelState.IsValid)
            {
                context.Add(wardStaff);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["WardId"] = new SelectList(context.Wards, "Id", "Name", wardStaff.WardId);
            return View(wardStaff);
        }

        // GET: WardStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wardStaff = await context.WardStaffs.SingleOrDefaultAsync(m => m.Id == id);
            if (wardStaff == null)
            {
                return NotFound();
            }
            ViewData["WardId"] = new SelectList(context.Wards, "Id", "Name", wardStaff.WardId);
            return View(wardStaff);
        }

        // POST: WardStaffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Position,WardId")] WardStaff wardStaff)
        {
            if (id != wardStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(wardStaff);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardStaffExists(wardStaff.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["WardId"] = new SelectList(context.Wards, "Id", "Name", wardStaff.WardId);
            return View(wardStaff);
        }

        // GET: WardStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wardStaff = await context.WardStaffs
                .Include(w => w.Ward)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wardStaff == null)
            {
                return NotFound();
            }

            return View(wardStaff);
        }

        // POST: WardStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wardStaff = await context.WardStaffs.SingleOrDefaultAsync(m => m.Id == id);
            context.WardStaffs.Remove(wardStaff);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WardStaffExists(int id)
        {
            return context.WardStaffs.Any(e => e.Id == id);
        }
    }
}
