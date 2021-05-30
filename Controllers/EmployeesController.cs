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
using Microsoft.AspNetCore.Identity;

namespace HumanResourcesDepartment.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public EmployeesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees;
            return View(await applicationDbContext.ToListAsync());
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

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            EmployeeEditViewModel model = new EmployeeEditViewModel
            {
                Id = id,
                PassportID = employee.PassportID,
                DOB = employee.DOB,
                Patronymic = employee.Patronymic,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                PhoneNumber = employee.PhoneNumber,
                IsEdited = true
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            model.IsEdited = true;

            if (ModelState.IsValid)
            {
                var employee = await _context.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();

                employee.PassportID = model.PassportID;
                employee.Patronymic = model.Patronymic;
                employee.Surname = model.Surname;
                employee.FirstName = model.FirstName;
                employee.DOB = model.DOB;

                _context.Update(employee);
                await _context.SaveChangesAsync();

                model.IsEdited = false;
            }

            return PartialView(model);
        }

        public async Task<IActionResult> EmployeeDismissal(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(new Dismissal { EmployeeId = id });
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeDismissal(Dismissal model)
        {
            if (ModelState.IsValid)
            {
                var employee = await _context.Employees.FindAsync(model.EmployeeId);

                if (employee == null)
                    return NotFound();

                employee.IsDismissed = true;
                model.Id = 0;

                _context.Employees.Update(employee);
                await _context.Dismissals.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> EmployeeTransfer(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
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

        public async Task<IActionResult> EmployeeSickLeave(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(new SickLeave { EmployeeId = id, Employee = employee });
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeSickLeave(SickLeave model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 0;
                await _context.SickLeaves.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> EmployeeVacation(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(new Vacation { EmployeeId = employee.Id, Employee = employee });
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeVacation(Vacation model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 0;
                await _context.Vacations.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> EmployeeBusinessTrip(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(new BusinessTrip { EmployeeId = employee.Id, Employee = employee });
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeBusinessTrip(BusinessTrip model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 0;
                await _context.BusinessTrips.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            searchString = searchString?.ToLower() ?? "";

            var employees = await _context.Employees
                .Where(e => e.FirstName.Contains(searchString) 
                    || e.Surname.ToLower().Contains(searchString)
                    || e.Patronymic.ToLower().Contains(searchString)
                    || e.Department.Name.ToLower().Contains(searchString)
                    || e.Post.PostName.ToLower().Contains(searchString))
                .ToListAsync();

            return PartialView("EmployeesList", employees);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
