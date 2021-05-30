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
    public class TimeSheetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public TimeSheetsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> EmployeeTimeSheet(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Picture)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public async Task<IActionResult> GetAttendanceMarks(int id, int month, int year)
        {
            return PartialView("AttendanceMarks", await FindTimeSheet(id, month, year));
        }

        private async Task<TimeSheet> FindTimeSheet(int id, int month, int year)
        {
            TimeSheet timeSheet = await _context.TimeSheets
                .Where(t => t.Month == month && t.Year == year && t.EmployeeId == id)
                .Include(t => t.Employee)
                    .ThenInclude(e => e.Department)
                .Include(t => t.Employee)
                    .ThenInclude(e => e.Post)
                .FirstOrDefaultAsync();

            if (timeSheet == null)
            {
                timeSheet = new TimeSheet
                {
                    EmployeeId = id,
                    Employee = await _context.Employees
                        .Include(e => e.Department)
                        .Include(e => e.Post)
                        .Where(e => e.Id == id)
                        .FirstOrDefaultAsync(),
                    Month = month,
                    Year = year,
                    AttendanceMarks = new string[DateTime.DaysInMonth(year, month)]
                };
            }

            DateTime startOfMonth = new DateTime(year, month, 1);
            DateTime endOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            timeSheet.BusinessTrips = await _context.BusinessTrips
                        .Where(b => b.TripStartDate <= endOfMonth
                            && b.TripEndDate >= startOfMonth
                            && b.EmployeeId == id)
                        .ToListAsync();
            timeSheet.Vacations = await _context.Vacations
                        .Where(v => v.VacationStartDate <= endOfMonth
                            && v.VacationEndDate >= startOfMonth
                            && v.EmployeeId == id)
                        .ToListAsync();
            timeSheet.SickLeaves = await _context.SickLeaves
                        .Where(s => s.SickLeaveStartDate <= endOfMonth
                            && s.SickLeaveEndDate >= startOfMonth
                            && s.EmployeeId == id)
                        .ToListAsync();

            timeSheet.SetGaps();

            return timeSheet;
        }

        [HttpPost]
        public async Task<IActionResult> SaveTimeSheet(TimeSheet model)
        {
            TimeSheet timeSheet = await _context.TimeSheets
                .Where(t => t.Month == model.Month && t.Year == model.Year && t.EmployeeId == model.EmployeeId)
                .FirstOrDefaultAsync();

            if (timeSheet == null)
            {
                await _context.TimeSheets.AddAsync(model);
                await _context.SaveChangesAsync();
                return PartialView("TimeSheetSaveResult");
            }

            timeSheet.AttendanceMarks = model.AttendanceMarks;
            _context.TimeSheets.Update(timeSheet);
            await _context.SaveChangesAsync();

            return PartialView("TimeSheetSaveResult");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTimeSheets(int month, int year)
        {
            List<TimeSheet> timeSheets = new List<TimeSheet>();
            TimeSheet timeSheet;
            var employees = await _context.Employees
                .ToListAsync();

            foreach (var item in employees)
            {
                timeSheet = await FindTimeSheet(item.Id, month, year);
                timeSheet.CalculateAmount();
                timeSheets.Add(timeSheet);
            }

            return PartialView("TimeSheets", timeSheets);
        }
    }
}
