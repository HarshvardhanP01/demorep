using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using DBFirstNeat.Data;
using DBFirstNeat.Models;
using DBFirstNeat.BizLayer;


namespace DBFirstNeat.Controllers
{
    public class DeptsController : Controller
    {
        //private readonly PayRollDbContext _context;
        private readonly PayRollBL _payrollBL;

       /* public DeptsController(PayRollDbContext context)
        {
            _context = context;
        }*/
        public DeptsController(PayRollBL context)
        {
            _payrollBL = context;
        }

        // GET: Depts
        public async Task<IActionResult> Index()
        {
            //return View(await _payrollBL..ToListAsync());
            return View(await _payrollBL.GetPayRollAsyc());
        }

        // GET: Depts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
/*
            var dept = await _context.Depts
                .FirstOrDefaultAsync(m => m.DeptNo == id);*/
            var dl=await _payrollBL.GetPayRollsAsync(id);

            if (dl == null)
            {
                return NotFound();
            }

            return View(dl);
        }

        // GET: Depts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Depts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptNo,Dname,Loc")] Dept dept)
        {
            if (ModelState.IsValid)
            {
               /* _context.Add(dept);
                await _context.SaveChangesAsync();*/
               try
                {
                    await _payrollBL.AddDeptAsync(dept);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty,ex.Message); // not about property
                    return View(dept);
                } 
            }
            return View(dept);
        }

        // GET: Depts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var dept = await _context.Depts.FindAsync(id);
            var dept = await _payrollBL.GetPayRollsAsync(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        // POST: Depts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptNo,Dname,Loc")] Dept dept)
        {
            if (id != dept.DeptNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // _context.Update(dept);
                    //await _context.SaveChangesAsync();
                    await _payrollBL.UpdateDeptAsync(dept);
                }
                catch (Exception ex)
                {
                    if (!await DeptExists(dept.DeptNo))
                    {
                        return NotFound();
                    }
                    //else
                    //{
                        ModelState.AddModelError(string.Empty, ex.Message); // not about property
                        return View(dept);
                   // }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }

        // GET: Depts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var dept = await _context.Depts
            //    .FirstOrDefaultAsync(m => m.DeptNo == id);
            var dept = await _payrollBL.GetPayRollsAsync(id);
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        // POST: Depts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var dept = await _context.Depts.FindAsync(id);
            var dept = await _payrollBL.GetPayRollsAsync(id);
            if (dept != null)
            {
                // _context.Depts.Remove(dept);
               await _payrollBL.RemoveDeptAsync(dept);
            }

           // await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DeptExists(int id)
        {
           // return _context.Depts.Any(e => e.DeptNo == id);
           var pd=await _payrollBL.GetPayRollsAsync(id);
            return pd != null;
        }
    }
}
