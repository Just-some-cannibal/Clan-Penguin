using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ClanPenguin.ViewModels;
using ClanPenguin.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace ClanPenguin.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ClanPenguinContext context)
        {
            DbContext = context;
            DbContext.Database.EnsureCreated();
        }

        public ClanPenguinContext DbContext { get; }


        public IActionResult Index()
        {
            Main Home = new ViewModels.Main()
            {
                Context = DbContext,
                Name = "Welcome!",
                Navbar = false,
                Sidebar = false
            };
            return View(Home);
        }
        public IActionResult Chatroom()
        {
            Main Chatroom = new Main()
            {
                Context = DbContext,
                Name = "Chatroom",
                Navbar = true,
                Sidebar = false

            };
            return View(Chatroom);
        }
        public IActionResult Profile(string user)
        {
            var name = "";
            if (User.Identity.IsAuthenticated)
            {
                name = User.Identity.Name;
            }
            else
            {
                name = "authorized";
            }
            Main Profile = new Main()
            {
                Context = DbContext,
                Name = name,
                Navbar = false,
                Sidebar = false,
                Id = user
            };
            return View(Profile);
        }
        public IActionResult About()
        {
            Main About = new Main()
            {
                Context = DbContext,
                Name = "About us",
                Navbar = false,
                Sidebar = false
            };
            return View(About);
        }
    }
}