using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAbbigliamento.Models;

namespace TaskAbbigliamento.DAL
{
    internal class UtenteDAL : IDal<Utente>
    {

        private static UtenteDAL? instance;
        public static UtenteDAL getIstance()
        {
            if (instance == null)
                instance= new UtenteDAL();

            return instance;

        }

        private UtenteDAL() { }


        public List<Utente> GetAll()
        {
            List<Utente> elencoUtenti = new List<Utente>();
            using(TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    elencoUtenti=ctx.Utentes.ToList();

                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return elencoUtenti;
        }
        public Utente GetById(int id)
        {
            Utente utente = new Utente();

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {

                    utente = ctx.Utentes.Single(s => s.UtenteId == id);



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }


            }

            return utente;

        }

        public bool Insert(Utente t)
        {
           bool risultato =false;
            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Utentes.Add(t);
                    ctx.SaveChanges();
                    risultato = true;


                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                return risultato;
        }
        public bool Update(Utente t)
        {
            bool risultato = false;

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {
                try
                {
                    ctx.Entry(t).State = EntityState.Modified;
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
        public bool Delete(Utente t)
        {
            bool risultato = false;

            using (TaskAbbigliamentoContext ctx = new TaskAbbigliamentoContext())
            {


                try
                {
                    ctx.Utentes.Remove(t);
                    ctx.SaveChanges();
                    risultato = true;

                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }










                return risultato;
        }

    }
}
