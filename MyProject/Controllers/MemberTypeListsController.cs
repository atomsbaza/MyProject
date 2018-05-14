using System.Linq;
using System.Threading.Tasks;
using MyProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;

namespace MyProject.Controllers
{
    public class MemberTypeListsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MemberTypeListsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: MemberTypeLists
        public IActionResult Index()
        {
            return View(_db.Membertypies.ToList());
        }

        // GET: MemberTypeLists/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberTypeLists memberTypeLists)
        {
            if (ModelState.IsValid)
            {
                _db.Add(memberTypeLists);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(memberTypeLists);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberTypes = _db.Membertypies.SingleOrDefault(m => m.Id == id);
            if (memberTypes == null)
            {
                return NotFound();
            }

            return View(memberTypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MemberTypeLists memberTypeLists)
        {
            if (memberTypeLists.Id != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(memberTypeLists);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(memberTypeLists);
        }


        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberTypes = _db.Membertypies.SingleOrDefault(m => m.Id == id);
            if (memberTypes == null)
            {
                return NotFound();
            }

            return View(memberTypes);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberTypes = _db.Membertypies.SingleOrDefault(m => m.Id == id);
            if (memberTypes == null)
            {
                return NotFound();
            }

            return View(memberTypes);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveMembertypes(MemberTypeLists memberTypeLists)
        {
            var deleteMemberTypes = await _db.Membertypies.SingleOrDefaultAsync(m => m.Id == memberTypeLists.Id);

            _db.Membertypies.Remove(deleteMemberTypes);
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