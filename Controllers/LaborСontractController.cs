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
using Microsoft.AspNetCore.Identity;

namespace HumanResourcesDepartment.Controllers
{
    public class LaborСontractController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public LaborСontractController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
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
                    Salary = model.Salary,
                    IsDismissed = false
                };

                LaborСontract laborСontract = new LaborСontract
                {
                    Employee = employee,
                    CompanyName = model.CompanyName,
                    DateOfAdoption = model.DateOfAdoption,
                    DateOfPreparation = model.DateOfPreparation,
                    Salary = model.Salary,
                    Base = model.Base,
                    DateOfAction = DateTime.Now,
                    HRManager = await _userManager.GetUserAsync(User)
                };

                await _context.LaborСontracts.AddAsync(laborСontract);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Employees");
            }

            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "PostName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");

            return View(model);
        }
    }
}
