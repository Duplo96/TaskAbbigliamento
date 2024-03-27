using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAbbigliamento.Models;

namespace TaskAbbigliamento.DAL
{
    internal class PrezzoDAL:IDal<Prezzo>
    {

        private static PrezzoDAL? instance;
        public static PrezzoDAL getIstance()
        {
            if (instance == null)
                instance = new PrezzoDAL();

            return instance;

        }

        private PrezzoDAL() { }


        public List<Prezzo> GetAll()
        {
            List<Prezzo> elencoPrezzo = new List<Prezzo>();
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    elencoPrezzo = ctx.Prezzos.ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return elencoPrezzo;
        }
        public Prezzo GetById(int id)
        {
            Prezzo prezzo = new Prezzo();

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {

                    prezzo = ctx.Prezzos.Single(s => s.PrezzoId == id);



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }


            }

            return prezzo;

        }

        public bool Insert(Prezzo t)
        {
            bool risultato = false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Prezzos.Add(t);
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
        public bool Update(Prezzo t)
        {
            bool risultato = false;

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Entry(t).State = EntityState.Modified;
                    ctx.SaveChanges();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }
        public bool Delete(Prezzo t)
        {
            bool risultato = false;

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {


                try
                {
                    ctx.Prezzos.Remove(t);
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
