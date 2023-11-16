using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApplicationElTiempo.Models;
using WebApplicationElTiempo.Services;

namespace WebApplicationElTiempo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IService _servicioApi;


        public HomeController(ILogger<HomeController> logger, IService servicioApi)
        {
            _logger = logger;
            _servicioApi = servicioApi;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task <IActionResult> UsuarioList(int? usrId)
        {
            List<Usuario> listau = await _servicioApi.ListUsuario(usrId);
            return View(listau);
        }
        public async Task<IActionResult> UsuarioUp(int Id)
        {
           Usuario lista = await _servicioApi.GetUsuario(Id);
            return View(lista);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> AddUsuario(Usuario obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.AddUsuario(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("UsuarioList");
            else
                //return NoContent();
                return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpUsuario(Usuario obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.UpUsuario(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("UsuarioList");
            else
                return NoContent();

        }
        public async Task<IActionResult> DelUsuario(int Id)
        {

            bool respuesta;

            if (Id != null)
            {
                respuesta = await _servicioApi.DelUsuario(Id);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("UsuarioList");
            else
                return NoContent();

        }


    }
}