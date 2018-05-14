using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Models;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data;

namespace MyProject.Controllers
{
    public class CardListsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CardListsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}