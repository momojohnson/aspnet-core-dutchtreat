using System;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Models;
using DutchTreat.Services;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController: Controller
    {
        private readonly ImailService _mailService;
        private readonly DutchContext _context;
      public AppController(ImailService mailService, DutchContext context){
            _mailService = mailService;
            _context = context;
      }      
      public IActionResult Index(){
            return View();
        }

        [HttpGet]
        public IActionResult Contact(){
            ViewBag.Title = "DutchTreat | Contact";
           
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact model){
            if(ModelState.IsValid){
             _mailService.SendMail("mo12g13@gmail.com", "sendgring@momo.com","Hello There", "Hello how are you!");
             ModelState.Clear();
             return RedirectToAction("Index");
            }
         return View();
        }


        public IActionResult About(){
            ViewBag.Title = "About us";
            return View();
        }

        public IActionResult Shop(){
            var results = _context.Products.ToList();
            return View(results);
        }
    }
}