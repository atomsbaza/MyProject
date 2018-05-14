using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;

namespace MyProject.Controllers
{
    public class MemberListsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MemberListsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string option = null, string search = null)
        {
            var users = _db.Users.ToList();

            if (option == "email" && search != null)
            {
                users = _db.Users.Where(m => m.Email.ToLower().Contains(search.ToLower())).ToList();
            }
            else
            {
                if (option == "name" && search != null)
                {
                    users = _db.Users.Where(m => m.FirstName.ToLower().Contains(search.ToLower())
                                                   || m.LastName.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    if (option == "phone" && search != null)
                    {
                        users = _db.Users.Where(m => m.PhoneNumber.ToLower().Contains(search.ToLower())).ToList();
                    }
                   
                }
            }
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberList memberLists)
        {
            if (ModelState.IsValid)
            {
                _db.Add(memberLists);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(memberLists);
        }

        // GET: Detail
        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = await _db.Users.SingleOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);

        }








        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _db.Dispose();
            }
        }
    }
}