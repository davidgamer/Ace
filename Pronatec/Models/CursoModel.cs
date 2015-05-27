using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pronatec.Entity;

namespace Pronatec.Models
{
    public class CursoModel
    {
        SysPronatecEntities db = new SysPronatecEntities();


        public List<Curso> todasCursos()
        {
            var lista = from c in db.Curso
                        select c;
            return lista.ToList();
        }

        public string adicionarCurso(Curso c)
        {
            string erro = null;
            try
            {
                db.Curso.AddObject(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public Curso obterCurso(int idCurso)
        {
            var lista = from c in db.Curso
                        where c.IdCurso == idCurso
                        select c;
            return lista.ToList().FirstOrDefault();
        }

        public string editarCurso(Curso c)
        {
            string erro = null;
            try
            {
                if (c.EntityState == System.Data.EntityState.Detached)
                {
                    db.Curso.Attach(c);
                }
                db.ObjectStateManager.ChangeObjectState(c, System.Data.EntityState.Modified);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirCurso(Curso c)
        {
            string erro = null;
            try
            {
                db.Curso.DeleteObject(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

    }
}