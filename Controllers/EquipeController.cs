using System;
using E_Players_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNetCore.Controllers
{
    [Route("Equipe")]

    
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
    
    [Route("Listar")]
        public IActionResult Index(){

            ViewBag.Equipes = equipeModel.ReadAll();

            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form){
            
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome =  form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}