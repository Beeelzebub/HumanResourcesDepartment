using HumanResourcesDepartment.Data;
using HumanResourcesDepartment.Models;
using HumanResourcesDepartment.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
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
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }


        [Authorize(Roles = "admin")]
        public IActionResult Index() => View(_userManager.Users.Where(u => u.UserName != "unknow").ToList());

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewData["Roles"] = new SelectList(new List<string> { "admin", "HR-Manager"});
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            ViewData["Roles"] = new SelectList(new List<string> { "admin", "HR-Manager" });
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            EditUserViewModel model;
            User user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var role = await _userManager.GetRolesAsync(user);

            model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Role = role.First()
            };

            ViewData["Roles"] = new SelectList(new List<string> { "admin", "HR-Manager" }, model.Role);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = model.FirstName;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.Patronymic = model.Patronymic;

                var updateResult = await _userManager.UpdateAsync(user);

                if (updateResult.Succeeded)
                {
                    if (model.Password != null)
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, model.Password);
                    }

                    await _userManager.AddToRoleAsync(user, model.Role);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in updateResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            ViewData["Roles"] = new SelectList(new List<string> { "admin", "HR-Manager" });
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var actions = (await LoadActionsFromDB()).Where(a => a.HRManager == user).ToList();

            foreach (var item in actions)
                item.HRManager = null;

            _context.UpdateRange(actions);
            await _context.SaveChangesAsync();

            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<Models.Action>> LoadActionsFromDB()
        {
            List<Models.Action> actions = new List<Models.Action>();

            actions.AddRange(await _context.Transfers.Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.BusinessTrips.Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.Dismissals.Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.LaborСontracts.Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.SickLeaves.Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.Vacations.Include(a => a.HRManager).ToListAsync());
            actions.AddRange(await _context.TimeSheets.Include(a => a.HRManager).ToListAsync());

            return actions;
        }
    }
}
