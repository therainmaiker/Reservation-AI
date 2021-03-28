using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation_V4.Data;
using Reservation_V4.Models;

namespace Reservation_V4.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager , UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }


        // GET: RoleController
        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();


            return View(users);
        }
        // GET: Role




        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController/Create
        public  ActionResult Create()
        {
            
            
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string Name)
        {
           
                var roles = await _roleManager.CreateAsync(new IdentityRole(Name));
                return RedirectToAction(nameof(Index));
           
        }


        [HttpGet]
        public IActionResult AssignRole()
        {
            var getuser = _userManager.Users.ToList();
            var getroles = _roleManager.Roles.ToList();
            ViewBag.getusers = new SelectList(getuser, "Id", "Email");
            ViewBag.getroles = new SelectList(getroles, "Name", "Name");

            return View();


        }


        [HttpPost]
        public async Task<IActionResult> AssignRole(IdentityRole userRole)
        {
            //find user from userRole.UserId
            //assign role to user
            //redirect to index

            var user = await _userManager.FindByIdAsync(userRole.Id);

            await _userManager.AddToRoleAsync(user, userRole.Name);

            return RedirectToAction(nameof(Index));
        }


























        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
