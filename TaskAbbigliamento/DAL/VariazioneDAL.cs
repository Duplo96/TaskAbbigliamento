using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAbbigliamento.Models;

namespace TaskAbbigliamento.DAL
{
    internal class VariazioneDAL : IDal<Variazione>
    {
        private static VariazioneDAL? instance;
        public static VariazioneDAL getIstance()
        {
            if (instance == null)
                instance = new VariazioneDAL();

            return instance;

        }

        private VariazioneDAL() { }

        public List<Variazione> GetAll()
        {
            List<Variazione> elencovariazioni = new List<Variazione>();
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Variaziones.ToList();


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                return elencovariazioni;
            }
        }
        public Variazione GetById(int id)
        {
            Variazione variazione = new Variazione();

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {

                try
                {
                    ctx.Variaziones.Single(s => s.VariazioneId == id);


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            return variazione;
        }

        public bool Insert(Variazione t)
        {
            bool risultato = false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {

                    ctx.Variaziones.Add(t);
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

        public bool Update(Variazione t)
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

        public bool Delete(Variazione t)
        {
            bool risultato = false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Variaziones.Remove(t);
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
