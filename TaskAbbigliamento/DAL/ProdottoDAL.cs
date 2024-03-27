using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAbbigliamento.Models;

namespace TaskAbbigliamento.DAL
{
    internal class ProdottoDAL:IDal<Prodotto>
    {

        private static ProdottoDAL? instance;
        public static ProdottoDAL getIstance()
        {
            if (instance == null)
                instance = new ProdottoDAL();

            return instance;

        }

        private ProdottoDAL() { }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elencoprodotti = new List<Prodotto>();
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Prodottos.ToList();


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                return elencoprodotti;
            }
        }
        public Prodotto GetById(int id)
        {
            Prodotto prodotto = new Prodotto();

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {

                try
                {
                    ctx.Prodottos.Single(s => s.ProdottoId == id);


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            return prodotto;
        }

        public bool Insert(Prodotto t)
        {
            bool risultato = false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {

                    ctx.Prodottos.Add(t);
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

        public bool Update(Prodotto t)
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

        public bool Delete(Prodotto t)
        {
            bool risultato = false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Prodottos.Remove(t);
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
