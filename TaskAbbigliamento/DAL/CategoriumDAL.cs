using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAbbigliamento.Models;

namespace TaskAbbigliamento.DAL
{
    internal class CategoriumDAL:IDal<Categorium>
    {

        private static CategoriumDAL? instance;
        public static CategoriumDAL getIstance()
        {
            if (instance == null)
                instance = new CategoriumDAL();

            return instance;

        }

        private CategoriumDAL() { }


        public List<Categorium> GetAll()
        {
            List<Categorium> elencoUtenti = new List<Categorium>();
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    elencoUtenti = ctx.Categoria.ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return elencoUtenti;
        }
        public Categorium GetById(int id)
        {
            Categorium categoria = new Categorium();

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {

                    categoria = ctx.Categoria.Single(s => s.CategoriaId == id);



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }


            }

            return categoria;

        }

        public bool Insert(Categorium t)
        {
            bool risultato = false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Categoria.Add(t);
                    ctx.SaveChanges();
                    risultato = true;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }
        public bool Update(Categorium t)
        {
            bool risultato = false;

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Entry(t).State = EntityState.Modified;
                    ctx.SaveChanges();
                    risultato= true;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }
        public bool Delete(Categorium t)
        {
            bool risultato = false;

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {


                try
                {
                    ctx.Categoria.Remove(t);
                    ctx.SaveChanges();
                    risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }
    }
}
