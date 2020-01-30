using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCRUD_Dapper.Models;
using ProjetoCRUD_Dapper.Repository;

namespace ProjetoCRUD_Dapper.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoRepository prodRepository = new ProdutoRepository();
        public ActionResult Index()
        {
            var produtos = prodRepository.ListarProdutos();
            return View(produtos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind]Produto produto)
        {
            try
            {
                //se o estado do modelo é válido (informações corretas)
                if (ModelState.IsValid)
                {
                    prodRepository.CriarProduto(produto);
                    return RedirectToAction();
                    
                }
                //retorna para a view o produto criado
                return View(produto);

            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Deletar(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar([Bind] Produto produto)
        {
            try
            {
                prodRepository.DeletarProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}