﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Data;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptsApiController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public DeptsApiController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/DeptsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dept>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/DeptsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dept>> GetDept(int id)
        {
            var dept = await _context.Departments.FindAsync(id);

            if (dept == null)
            {
                return NotFound();
            }

            return dept;
        }

        // PUT: api/DeptsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDept(int id, Dept dept)
        {
            if (id != dept.DeptNo)
            {
                return BadRequest();
            }

            _context.Entry(dept).State = EntityState.Modified;
           // _context.Departments.Update(dept);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DeptsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dept>> PostDept(Dept dept)
        {
            _context.Departments.Add(dept);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeptExists(dept.DeptNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDept", new { id = dept.DeptNo }, dept);
        }

        // DELETE: api/DeptsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptExists(int id)
        {
            return _context.Departments.Any(e => e.DeptNo == id);
        }
    }
}