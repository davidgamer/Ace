using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pronatec.Entity;

namespace Pronatec.Models
{
    public class PessoaModel
    {
        SysPronatecEntities db = new SysPronatecEntities();


        public List<Pessoa> todasPessoas()
        {
            var lista = from p in db.Pessoa
                        select p;
            return lista.ToList();
        }

        public string adicionarPessoa(Pessoa p)
        {
            string erro = null;
            try
            {
                db.Pessoa.AddObject(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Pessoa obterPessoa(int idPessoa)
        {
            var lista = from p in db.Pessoa
                        where p.IDPessoa == idPessoa
                        select p;
            return lista.ToList().FirstOrDefault();
        }

        public string editarPessoa(Pessoa p)
        {
            string erro = null;
            try
            {
                if (p.EntityState == System.Data.EntityState.Detached)
                {
                    db.Pessoa.Attach(p);
                }
                db.ObjectStateManager.ChangeObjectState(p, System.Data.EntityState.Modified);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirPessoa(Pessoa p)
        {
            string erro = null;
            try
            {
                db.Pessoa.DeleteObject(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string validarPessoa(Pessoa p)
        {
            if (p.Nome == null || p.Nome == "")
            {
                return "O nome não pode ser vazio!";
            }
            if (p.CPF == null || p.CPF.Length > 11)
            {
                return "CPF inválido";
            }
            if (p.DataNas == null || p.DataNas > DateTime.Now.Date)
            {
                return "Data de nascimento inválida";
            }

            return null;
        }





    }
}