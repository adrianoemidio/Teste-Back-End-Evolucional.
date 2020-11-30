using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppEvolucional.Models;
using AppEvolucional.DataLibrary.BusinessLogic;
using System.IO;

namespace AppEvolucional.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

             _logger = logger;
        }

        
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserViewModel modelo)
        {
            if (ModelState.IsValid){
                var result = await signInManager.PasswordSignInAsync(
                    modelo.Login, modelo.Senha, false, false);
 

                if (result.Succeeded)
                {
                    return View("UserArea");

                }else
                {
                    ModelState.AddModelError(string.Empty, "Nome de usuário ou senha incorreta");
                    return View(modelo);
                }
                
        }

            return View(modelo);


        }

        public IActionResult UserArea(string botao1,string botao2)
        {
    
            var isAuthenticated = User.Identity.IsAuthenticated;
            
            if(isAuthenticated)
            {

                if(botao1 != null)
                {
                    Console.WriteLine("Botão 1 pressionado");

                    Tablefill.startOperation();

                    Console.WriteLine("ok");

                }else if(botao2 != null)
                {
                    Console.WriteLine("Botão 2 pressionado");

                    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileName = "Notas.xlsx";

                    MemoryStream stream = ExportXLSX.Export();

                    Console.WriteLine("ok");

                    var content = stream.ToArray();
                    return File(content, contentType, fileName);

                                        
                }

            return View();

            }

            return Redirect("Index");

            

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
