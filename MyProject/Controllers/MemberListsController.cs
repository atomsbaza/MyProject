using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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


        public async Task<IActionResult> Edit(string id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", applicationUser);
            }
            else
            {
                var userInDb = _db.Users.SingleOrDefault(m => m.Id == applicationUser.Id);
                if (userInDb == null)
                {
                    return NotFound();
                }

                //_db.Users.Update(applicationUser);
                userInDb.FirstName = applicationUser.FirstName;
                userInDb.LastName = applicationUser.LastName;
                userInDb.Email = applicationUser.Email;
                userInDb.Address = applicationUser.Address;
                userInDb.City = applicationUser.City;
                userInDb.PostalCode = applicationUser.PostalCode;
                userInDb.PhoneNumber = applicationUser.PhoneNumber;
               
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(string id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCustomer(string id)
        {
            var userinDb = await _db.Users.SingleOrDefaultAsync(m => m.Id == id);
            _db.Users.Remove(userinDb);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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