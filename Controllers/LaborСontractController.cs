using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HumanResourcesDepartment.Data;
using HumanResourcesDepartment.Models;
using HumanResourcesDepartment.ViewModels;
using System.IO;

namespace HumanResourcesDepartment.Controllers
{
    public class LaborСontractController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LaborСontractController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LaborСontracts.Include(l => l.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborСontract = await _context.LaborСontracts
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laborСontract == null)
            {
                return NotFound();
            }

            return View(laborСontract);
        }

        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "PostName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LaborContractViewModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                Picture picture = null;

                if (model.Image != null)
                {
                    using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Image.Length);
                    }

                    picture = new Picture { Image = imageData };
                }


                Employee employee = new Employee
                {
                    FirstName = model.FirstName,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    PassportID = model.PassportID,
                    PhoneNumber = model.PhoneNumber,
                    DOB = model.DOB,
                    Picture = picture,
                    DepartmentId = model.DepartmentId,
                    PostId = model.PostId,
                    Experience = model.Experience,
                    Salary = model.Salary
                };

                LaborСontract laborСontract = new LaborСontract
                {
                    Employee = employee,
                    CompanyName = model.CompanyName,
                    DateOfAdoption = model.DateOfAdoption,
                    DateOfPreparation = model.DateOfPreparation,
                    Salary = model.Salary,
                    Base = model.Base
                };

                await _context.LaborСontracts.AddAsync(laborСontract);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Employees");
            }

            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "PostName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborСontract = await _context.LaborСontracts.FindAsync(id);
            if (laborСontract == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", laborСontract.EmployeeId);
            return View(laborСontract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,CompanyName,DateOfPreparation,DateOfAdoption,Salary,Base")] LaborСontract laborСontract)
        {
            if (id != laborСontract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laborСontract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaborСontractExists(laborСontract.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", laborСontract.EmployeeId);
            return View(laborСontract);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborСontract = await _context.LaborСontracts
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laborСontract == null)
            {
                return NotFound();
            }

            return View(laborСontract);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laborСontract = await _context.LaborСontracts.FindAsync(id);
            _context.LaborСontracts.Remove(laborСontract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaborСontractExists(int id)
        {
            return _context.LaborСontracts.Any(e => e.Id == id);
        }
    }
}
