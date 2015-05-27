using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pronatec.Entity;
using Pronatec.Models;

namespace Pronatec.Controllers
{
    public class CursoController : Controller
    {
        CursoModel curModel = new CursoModel();

        public ActionResult Index()
        {
            return View(curModel.todasCursos());
        }

        public ActionResult Edit(int id)
        {
            Curso c = new Curso();
            ViewBag.Titulo = "Nova Curso";
            if (id != 0)
            {
                c = curModel.obterCurso(id);
                ViewBag.Titulo = "Editar Curso";
            }
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Curso c)
        {
            string erro = null;
            if (c.IdCurso == 0)
                erro = curModel.adicionarCurso(c);
            else
                erro = curModel.editarCurso(c);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(c);
            }
        }

        public ActionResult Delete(int id)
        {
            Curso c = curModel.obterCurso(id);
            curModel.excluirCurso(c);
            return RedirectToAction("Index");
        }
    }
}
