using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pronatec.Models;
using Pronatec.Entity;

namespace Pronatec.Controllers
{
    public class PessoaController : Controller
    {
        PessoaModel pessoaModel = new PessoaModel();

        public ActionResult Index()
        {
            return View(pessoaModel.todasPessoas());
        }

        public ActionResult Edit(int id)
        {
            Pessoa p = new Pessoa();
            ViewBag.Titulo = "Nova Candidato";
            if (id != 0)
            {
                p = pessoaModel.obterPessoa(id);
                ViewBag.Titulo = "Editar Pessoa";
            }
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Pessoa p)
        {
            string erro = null;
            if (p.IDPessoa == 0)
                erro = pessoaModel.adicionarPessoa(p);
            else
                erro = pessoaModel.editarPessoa(p);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(p);
            }
        }

        public ActionResult Delete(int id)
        {
            Pessoa p = pessoaModel.obterPessoa(id);
            pessoaModel.excluirPessoa(p);
            return RedirectToAction("Index");
        }
    }
}
