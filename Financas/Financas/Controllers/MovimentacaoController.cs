using Financas.DAO;
using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Controllers
{
    public class MovimentacaoController : Controller
    {

        private MovimentacaoDAO movimentacaoDAO;
        private UsuarioDAO usuarioDAO;
        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDAO)
        {
            this.movimentacaoDAO = movimentacaoDAO;
            this.usuarioDAO = usuarioDAO;
        }

        // GET: Movimentacao
        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View();
        }

        // GET: Movimentacao
        public ActionResult Index()
        {
            return View(movimentacaoDAO.Lista());
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                movimentacaoDAO.Adiciona(movimentacao);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View("Form");
            }
        }
    }
}