using HumanResourcesDepartment.Data;
using HumanResourcesDepartment.Models;
using HumanResourcesDepartment.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ManagementController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            return View();
        }

        public async Task<IActionResult> History()
        {
            var employeesId = await _context.Employees.Select(e => new { Id = e.Id, Name = e.GetFullName() }).ToListAsync();
            employeesId.Add(new { Id = 0, Name = "Все" });
            employeesId.Reverse();
            ViewData["EmployeesId"] = new SelectList(employeesId, "Id", "Name", 0);

            var HRManagerId = (await _userManager.GetUsersInRoleAsync("HR-Manager")).Select(u => new { Id = u.Id, Name = u.GetFullName() }).ToList();
            HRManagerId.Add(new { Id = "0", Name = "Все" });
            HRManagerId.Reverse();
            ViewData["HRManagerId"] = new SelectList(HRManagerId, "Id", "Name", 0);
            
            return View(await LoadActionsFromDB());
        }

        public async Task<IActionResult> GetActions(ActionsFilterViewModel model)
        {
            List<Models.Action> actions = await LoadActionsFromDB();

            if (model.HRManagerId != "0")
                actions = actions.Where(a => a.HRManager.Id == model.HRManagerId).ToList();

            if (!model.AllTime)
                actions = actions.Where(a => a.DateOfAction.ToShortDateString() == model.Date?.ToShortDateString()).ToList();

            if (model.EmployeeId != 0)
                actions = actions.Where(a => a.Employee.Id == model.EmployeeId).ToList();

            if (model.ActionId == 1)
                actions = actions.Where(a => a is LaborСontract).ToList();

            if (model.ActionId == 2)
                actions = actions.Where(a => a is TimeSheet).ToList();

            if (model.ActionId == 3)
                actions = actions.Where(a => a is Dismissal).ToList();

            if (model.ActionId == 4)
                actions = actions.Where(a => a is BusinessTrip).ToList();

            if (model.ActionId == 5)
                actions = actions.Where(a => a is SickLeave).ToList();

            if (model.ActionId == 6)
                actions = actions.Where(a => a is Transfer).ToList();

            return PartialView("ActionsList", actions);
        }

        public async Task<List<Models.Action>> LoadActionsFromDB()
        {
            List<Models.Action> actions = new List<Models.Action>();

            actions.AddRange(await _context.BusinessTrips.Include(a => a.Employee).Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.Dismissals.Include(a => a.Employee).Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.LaborСontracts.Include(a => a.Employee).Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.SickLeaves.Include(a => a.Employee).Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.Transfers.Include(a => a.Employee).Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.Vacations.Include(a => a.Employee).Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.TimeSheets.Include(a => a.Employee).Include(a => a.HRManager).ToListAsync());

            return actions;
        }
    }
}
