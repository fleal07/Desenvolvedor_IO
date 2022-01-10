using System;
using System.Linq;
using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
         private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome =  "Luis Felipe Leal",
                DataNascimento = DateTime.Now,
                Email = "fleal07@gmail.com"
            };
            
            _contexto.Alunos.Add(aluno); //Adiciona o aluno no contexto
            _contexto.SaveChanges(); //Atualiza na base de dados

            var aluno2 = _contexto.Alunos.Find(aluno.Id); //Busca o aluno pelo ID
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "fleal07@gmail.com"); //Busca o primeiro aluno encontrado pelo email
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Eduardo"); //Busca uma coleção de alunos pelo nome Eduardo

            aluno.Nome = "João";
            _contexto.Alunos.Update(aluno); //Atualiza o aluno no contexto
            _contexto.SaveChanges();        //Atualiza na base de dados

            _contexto.Alunos.Remove(aluno); //Remove o aluno no contexto
            _contexto.SaveChanges();        //Atualiza na base de dados

            return View("_Layout");
        }
    }
}