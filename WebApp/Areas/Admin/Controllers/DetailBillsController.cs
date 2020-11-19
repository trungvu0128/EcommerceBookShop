using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Admin.Data;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetailBillsController : Controller
    {
        private readonly DPContext _context;

        public DetailBillsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/DetailBills
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.detailBills.Include(d => d.Bill).Include(d => d.Product);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/DetailBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailBill = await _context.detailBills
                .Include(d => d.Bill)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailBill == null)
            {
                return NotFound();
            }

            return View(detailBill);
        }

        // GET: Admin/DetailBills/Create
        public IActionResult Create()
        {
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "id", "Name");
            return View();
        }

        // POST: Admin/DetailBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Price,BillId,ProductName,ProductId")] DetailBill detailBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", detailBill.BillId);
            ViewData["ProductId"] = new SelectList(_context.Products, "id", "Name", detailBill.ProductId);
            return View(detailBill);
        }

        // GET: Admin/DetailBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailBill = await _context.detailBills.FindAsync(id);
            if (detailBill == null)
            {
                return NotFound();
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", detailBill.BillId);
            ViewData["ProductId"] = new SelectList(_context.Products, "id", "Name", detailBill.ProductId);
            return View(detailBill);
        }

        // POST: Admin/DetailBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Price,BillId,ProductName,ProductId")] DetailBill detailBill)
        {
            if (id != detailBill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailBillExists(detailBill.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", detailBill.BillId);
            ViewData["ProductId"] = new SelectList(_context.Products, "id", "Name", detailBill.ProductId);
            return View(detailBill);
        }

        // GET: Admin/DetailBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailBill = await _context.detailBills
                .Include(d => d.Bill)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailBill == null)
            {
                return NotFound();
            }

            return View(detailBill);
        }

        // POST: Admin/DetailBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailBill = await _context.detailBills.FindAsync(id);
            _context.detailBills.Remove(detailBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailBillExists(int id)
        {
            return _context.detailBills.Any(e => e.Id == id);
        }
    }
}
