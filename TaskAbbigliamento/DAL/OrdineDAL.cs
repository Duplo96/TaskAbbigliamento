using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAbbigliamento.Models;

namespace TaskAbbigliamento.DAL
{
    internal class OrdineDAL : IDal<Ordine>
    {

        private static OrdineDAL? instance;
        public static OrdineDAL getIstance()
        {
            if (instance == null)
                instance = new OrdineDAL();

            return instance;

        }

        private OrdineDAL() { }

        public List<Ordine> GetAll()
        {
            List<Ordine> elencoOrdini = new List<Ordine>();
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Ordines.ToList();


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }


                return elencoOrdini;
            }
        }
        public Ordine GetById(int id)
        {
            Ordine ordine = new Ordine();

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {

                try
                {
                    ctx.Ordines.Single(s => s.OrdineId == id);


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            return ordine;
        }

        public bool Insert(Ordine t)
        {
            bool risultato = false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {

                    ctx.Ordines.Add(t);
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

        public bool Update(Ordine t)
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

        public bool Delete(Ordine t)
        {
            bool risultato=false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext()) {
                try 
                {
                    ctx.Ordines.Remove(t);
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
