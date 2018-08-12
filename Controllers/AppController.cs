using System;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.Models;
using DutchTreat.Services;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController: Controller
    {
        private readonly ImailService _mailService;
    
        private readonly IRepository<Product> _contextRepo;
      public AppController(ImailService mailService,  IRepository<Product> contextRepo){
            _mailService = mailService;
            _contextRepo = contextRepo;
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
            
            return View(_contextRepo.GetAll());
        }
    }
}