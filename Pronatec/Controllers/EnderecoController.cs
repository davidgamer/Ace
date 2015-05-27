using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pronatec.Entity;
using Pronatec.Models;

namespace Pronatec.Controllers
{
    public class EnderecoController : Controller
    {


        SysPronatecEntities db = new SysPronatecEntities();


        public List<Endereço> todasEnderecos()
        {
            var lista = from e in db.Endereço
                        select e;
            return lista.ToList();
        }

        public string adicionarEndereco(Endereço e)
        {
            string erro = null;
            try
            {
                db.Endereço.AddObject(e);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Endereço obterEndereco(int idEndereco)
        {
            var lista = from e in db.Endereço
                        where e.IDEndereco == idEndereco
                        select e;
            return lista.ToList().FirstOrDefault();
        }

        public string editarEndereco(Endereço e)
        {
            string erro = null;
            try
            {
                if (e.EntityState == System.Data.EntityState.Detached)
                {
                    db.Endereço.Attach(e);
                }
                db.ObjectStateManager.ChangeObjectState(e, System.Data.EntityState.Modified);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirEndereco(Endereço e)
        {
            string erro = null;
            try
            {
                db.Endereço.DeleteObject(e);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        /*   public string validarEndereco(Endereço p)
           {
               if (p.Nome == null || p.Nome == "")
               {
                   return "O nome não pode ser vazio!";
               }
               if (p.CPF == null || p.CPF> 11)
               {
                   return "CPF inválido";
               }
               if (p.DataNas == null || p.DataNas > DateTime.Now.Date)
               {
                   return "Data de nascimento inválida";
               }
           
               return null;
           }*/

    }
}
