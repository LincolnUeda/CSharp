using ListaTarefas.Data;
using ListaTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ListaTarefas.Controllers
{
    public class HomeController : Controller
    {
       private readonly AppDbContext _context;
        public HomeController(AppDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public IActionResult Index(string id)
        {
            var filtros = new Filtros(id);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();//busca do banco
            ViewBag.Status = _context.Status.ToList(); //busca do banco
            ViewBag.Vencimento = Filtros.VencimentoValoresFiltro; //dicionario criado na classe Filtros

            //criando query para buscar no banco
            IQueryable<TarefaModel> consulta = _context.Tarefas.Include(c => c.Categoria).Include(s => s.Status);

            if (filtros.TemCategoria)
            {
                consulta = consulta.Where(t => t.CategoriaId == filtros.CategoriaId);
            }

            if (filtros.TemStatus)
            {
                consulta = consulta.Where(t => t.StatusId == filtros.StatusId);
            }

            if (filtros.TemVencimento)
            {

                var hoje = DateTime.Today;

                if (filtros.EPassado)
                {
                    consulta = consulta.Where(t => t.DataVencimento < hoje);
                }

                if (filtros.EFuturo)
                {
                    consulta = consulta.Where(t => t.DataVencimento > hoje);
                }

                if (filtros.EPresente)
                {
                    consulta = consulta.Where(t => t.DataVencimento == hoje);
                }

            }

            var tarefas = consulta.OrderBy(t => t.DataVencimento).ToList();

            return View(tarefas);
        }

        public IActionResult Adicionar()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Status = _context.Status.ToList();
            var tarefa = new TarefaModel { StatusId = 1};
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Filtrar(string[] filtro)
        {
            string id = string.Join("-", filtro);
                
            return RedirectToAction("Index",new {ID = id });
        }

        [HttpPost]
        public IActionResult MarcarCompleto([FromRoute] string id, TarefaModel tarefaSelecionada)
        {
            tarefaSelecionada = _context.Tarefas.Find(tarefaSelecionada.Id);
            
            if (tarefaSelecionada != null)
            {
                tarefaSelecionada.StatusId = 2;
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Adicionar(TarefaModel Tarefa) {
            if (ModelState.IsValid)
            {
                _context.Add(Tarefa);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Categorias = _context.Categorias.ToList();
                ViewBag.Status = _context.Status.ToList();
                return View(Tarefa);
            }
        

        }

        [HttpPost]
        public IActionResult DeletarCompletos (string id)
        {
            var paraDeletar = _context.Tarefas.Where(s => s.StatusId == 2).ToList();
            foreach(var tarefa in paraDeletar)
            {
                _context.Remove(tarefa);
                
            }
            _context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }

    }
}
