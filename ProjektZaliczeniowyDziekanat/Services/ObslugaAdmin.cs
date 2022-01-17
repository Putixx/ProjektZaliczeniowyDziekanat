using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjektZaliczeniowyDziekanat.Services
{
    public class ObslugaAdmin : IObslugaAdmin
    {
        private readonly DziekanatContext dziekanatDb;

        public ObslugaAdmin(DziekanatContext dziekanatDb)
        {
            this.dziekanatDb = dziekanatDb;
        }

        public List<Zajecia> PobierzPlanZajec(string searchString)
        {
            IQueryable<Zajecia> zajecia = from z in dziekanatDb.PlanZajec select z;

            if (!String.IsNullOrEmpty(searchString))
                zajecia = WyszukajZajecia(searchString, zajecia);

            return zajecia.ToList();
        }

        public IQueryable<Zajecia> WyszukajZajecia(string searchString, IQueryable<Zajecia> zajecia)
        {
            if (!String.IsNullOrEmpty(searchString))
                zajecia = zajecia.Where(z => z.NazwaPrzedmiotu.Contains(searchString));

            return zajecia;
        }

        public List<StudentDTO> PobierzListeStudentow(string searchString)
        {
            IQueryable<StudentDTO> studenci = from s in dziekanatDb.StudenciDTO select s;

            if (!String.IsNullOrEmpty(searchString))
                studenci = WyszukajStudent(searchString, studenci);

            return studenci.ToList();
        }

        public IQueryable<StudentDTO> WyszukajStudent(string searchString, IQueryable<StudentDTO> studenci)
        {
            if (!String.IsNullOrEmpty(searchString))
                studenci = studenci.Where(z => z.Nazwisko.Equals(searchString));

            return studenci;
        }

        public List<WykladowcaDTO> PobierzListeWykladowcow(string searchString)
        {
            IQueryable<WykladowcaDTO> wykladowcy = from s in dziekanatDb.WykladowcyDTO select s;

            if (!String.IsNullOrEmpty(searchString))
                wykladowcy = WyszukajWykladowca(searchString, wykladowcy);

            return wykladowcy.ToList();
        }

        public IQueryable<WykladowcaDTO> WyszukajWykladowca(string searchString, IQueryable<WykladowcaDTO> wykladowcy)
        {
            if (!String.IsNullOrEmpty(searchString))
                wykladowcy = wykladowcy.Where(z => z.Nazwisko.Equals(searchString));

            return wykladowcy;
        }

        public bool DodajDoPlanu(string GrupaNr, string NazwaPrzedmiotu, string TerminZajec, string WykladowcaID)
        {
            using var transaction = dziekanatDb.Database.BeginTransaction();

            try
            {
                if (String.IsNullOrEmpty(GrupaNr) || String.IsNullOrEmpty(NazwaPrzedmiotu) || String.IsNullOrEmpty(TerminZajec) || String.IsNullOrEmpty(WykladowcaID))
                {
                    transaction.Rollback();
                    return true;
                }

                DateTime terminZajec;

                if(!DateTime.TryParse(TerminZajec, out terminZajec))
                {
                    transaction.Rollback();
                    return true;
                }

                int wykladowcaID;

                if (!int.TryParse(WykladowcaID, out wykladowcaID))
                {
                    transaction.Rollback();
                    return true;
                }
                Przedmiot przedmiot = dziekanatDb.Przedmioty.FirstOrDefault(x => x.NazwaPrzedmiotu == NazwaPrzedmiotu);

                if(przedmiot == null)
                {
                    Przedmiot nowyPrzedmiot = new Przedmiot(NazwaPrzedmiotu);
                    dziekanatDb.Przedmioty.Add(nowyPrzedmiot);
                    dziekanatDb.SaveChanges();
                }


                Zajecia noweZaj = new Zajecia(GrupaNr, NazwaPrzedmiotu, terminZajec, wykladowcaID);

                dziekanatDb.PlanZajec.Add(noweZaj);
                dziekanatDb.SaveChanges();

                transaction.Commit();

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);

                transaction.Rollback();

                return false;
            }
        }

        public bool UsunZPlanu(string ZajeciaID)
        {
            using var transaction = dziekanatDb.Database.BeginTransaction();

            try
            {
                int zajeciaID;

                if(!int.TryParse(ZajeciaID, out zajeciaID))
                {
                    transaction.Rollback();
                    return true;
                }

                Zajecia zajecia = dziekanatDb.PlanZajec.FirstOrDefault(x => x.ZajeciaID == zajeciaID);


                dziekanatDb.PlanZajec.Remove(zajecia);
                dziekanatDb.SaveChanges();

                transaction.Commit();

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);

                transaction.Rollback();

                return false;
            }
        }

        public bool DodajStudenta(string NumerIndeksu, string Imie, string Nazwisko, string DataUrodzenia, string MiejsceUrodzenia, string AdresZamieszkania, string MiejsceZamieszkania, string Narodowosc, string Obywatelstwo, string PESEL, string GrupaNr)
        {
            using var transaction = dziekanatDb.Database.BeginTransaction();

            try
            {
                if (String.IsNullOrEmpty(NumerIndeksu) || String.IsNullOrEmpty(Imie) || String.IsNullOrEmpty(Nazwisko) || String.IsNullOrEmpty(DataUrodzenia) || String.IsNullOrEmpty(MiejsceUrodzenia) || String.IsNullOrEmpty(AdresZamieszkania) || String.IsNullOrEmpty(MiejsceZamieszkania) || String.IsNullOrEmpty(Narodowosc) || String.IsNullOrEmpty(Obywatelstwo) || String.IsNullOrEmpty(PESEL) || String.IsNullOrEmpty(GrupaNr))
                {
                    transaction.Rollback();
                    return true;
                }

                DateTime dataUrodzenia;

                if (!DateTime.TryParse(DataUrodzenia, out dataUrodzenia))
                {
                    transaction.Rollback();
                    return true;
                }

                if (PESEL.Length > 11)
                {
                    transaction.Rollback();
                    return true;
                }

                Student nowyStudent = new Student(NumerIndeksu, Imie, Nazwisko, GrupaNr);

                dziekanatDb.Studenci.Add(nowyStudent);
                dziekanatDb.SaveChanges();

                StudentDTO nowyStudentDTO = new StudentDTO(NumerIndeksu, Imie, Nazwisko, dataUrodzenia, MiejsceUrodzenia, AdresZamieszkania, MiejsceZamieszkania, Narodowosc, Obywatelstwo, PESEL, GrupaNr);

                dziekanatDb.StudenciDTO.Add(nowyStudentDTO);
                dziekanatDb.SaveChanges();

                StudentDTO dodanyStudentDTO = dziekanatDb.StudenciDTO.FirstOrDefault(x => x.NumerIndeksu == nowyStudentDTO.NumerIndeksu);
                string Login = dodanyStudentDTO.Imie + dodanyStudentDTO.Nazwisko;
                string Haslo = dodanyStudentDTO.PESEL;
                StudentLogowanie studentlogowanie = new StudentLogowanie(dodanyStudentDTO.StudentID, Login, Haslo);

                dziekanatDb.StudenciLogowanie.Add(studentlogowanie);
                dziekanatDb.SaveChanges();

                transaction.Commit();

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);

                transaction.Rollback();

                return false;
            }
        }
        public bool UsunStudenta(string StudentID)
        {
            using var transaction = dziekanatDb.Database.BeginTransaction();

            try
            {
                if (String.IsNullOrEmpty(StudentID))
                {
                    transaction.Rollback();
                    return true;
                }

                int studentID;

                if (!int.TryParse(StudentID, out studentID))
                {
                    transaction.Rollback();
                    return true;
                }

                StudentDTO studentDTO = dziekanatDb.StudenciDTO.FirstOrDefault(x => x.StudentID == studentID);

                if (studentDTO == null)
                {
                    transaction.Rollback();
                    return true;
                }

                Student student = dziekanatDb.Studenci.FirstOrDefault(x => x.NumerIndeksu == studentDTO.NumerIndeksu);
                StudentLogowanie studentlogowanie = dziekanatDb.StudenciLogowanie.FirstOrDefault(x => x.StudentID == student.StudentID);

                dziekanatDb.StudenciLogowanie.Remove(studentlogowanie);
                dziekanatDb.StudenciDTO.Remove(studentDTO);
                dziekanatDb.Studenci.Remove(student);
                dziekanatDb.SaveChanges();

                transaction.Commit();

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);

                transaction.Rollback();

                return false;
            }
        }
        //public bool DodajWykladowce(string GrupaNr, string NazwaPrzedmiotu, string TerminZajec, string WykladowcaID);
        //public bool UsunWykladowce(string NazwaPrzedmiotu);
    }
}
