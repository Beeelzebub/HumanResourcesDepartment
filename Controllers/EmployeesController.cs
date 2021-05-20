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

namespace HumanResourcesDepartment.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Picture);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Picture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            ViewData["PictureId"] = new SelectList(_context.Pictures, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,Surname,Patronymic,PhoneNumber,PassportID,DOB,PictureId,MaritalStatusId,DepartmentId,Experience")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", employee.DepartmentId);
            ViewData["PictureId"] = new SelectList(_context.Pictures, "Id", "Id", employee.PictureId);
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", employee.DepartmentId);
            ViewData["PictureId"] = new SelectList(_context.Pictures, "Id", "Id", employee.PictureId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Surname,Patronymic,PhoneNumber,PassportID,DOB,PictureId,MaritalStatusId,DepartmentId,Experience")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", employee.DepartmentId);
            ViewData["PictureId"] = new SelectList(_context.Pictures, "Id", "Id", employee.PictureId);
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Picture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetEmployeeInfo(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Picture)
                .Include(e => e.Post)
                .Include(e => e.Department)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            return PartialView("EmployeeInfo", employee);
        }

        public async Task<IActionResult> EmployeeTransfer(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            
            if (_context.Employees == null)
                return NotFound();

            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "PostName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");

            return View(new EmployeeTransferViewModel { EmployeeId = id });
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeTransfer(EmployeeTransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = await _context.Employees
                    .Where(e => e.Id == model.EmployeeId)
                    .FirstOrDefaultAsync();

                if (employee == null)
                    return NotFound();

                Transfer transfer = new Transfer
                {
                    OldDepartmentId = employee.DepartmentId,
                    OldPostId = employee.PostId,
                    NewDepartmentId = model.NewDepartmentId,
                    NewPostId = model.NewPostId,
                    NewSalary = model.NewSalary,
                    Employee = employee,
                    DateOfTransfer = model.DateOfTransfer
                };

                employee.DepartmentId = model.NewDepartmentId;
                employee.PostId = model.NewPostId;
                employee.Salary = model.NewSalary;

                await _context.Transfers.AddAsync(transfer);
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "PostName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");

            return View(model);
        }



        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
