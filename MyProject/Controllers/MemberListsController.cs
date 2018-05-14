using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var user = _db.Members.ToList();
            return View(user);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _db.Dispose();
            }
        }
    }
}