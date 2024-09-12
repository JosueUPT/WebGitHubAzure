using Chambilla_GitHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chambilla_GitHub.Controllers
{
    public class AccountController : Controller
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new AccountViewModel
            {
                Usuarios = usuarios
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(Usuario model)
        {
            if (ModelState.IsValid)
            {
                usuarios.Add(model);
                return RedirectToAction("Index");
            }

            var viewModel = new AccountViewModel
            {
                Usuarios = usuarios,
                RegistroError = "Por favor, corrija los errores en el formulario."
            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);
            var viewModel = new AccountViewModel
            {
                Usuarios = usuarios
            };

            if (usuario != null)
            {
                ViewBag.LoginMessage = $"¡Login exitoso! Bienvenido {usuario.Nombre}";
            }
            else
            {
                ViewBag.ErrorMessage = "Email o contraseña incorrectos.";
            }

            return View("Index", viewModel);
        }
    }
}