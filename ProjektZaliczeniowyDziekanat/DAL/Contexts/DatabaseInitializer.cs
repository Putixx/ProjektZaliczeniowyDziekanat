using System;
using System.Linq;
using ProjektZaliczeniowyDziekanat.DAL.Models;

namespace ProjektZaliczeniowyDziekanat.DAL.Contexts
{
    public class DatabaseInitializer
    {
        public static void Initialize(DziekanatContext context)
        {
            context.Database.EnsureCreated();

            InitializeGrupy(ref context);
            InitializeStudenci(ref context);
            InitializeStudenciLogowanie(ref context);
            InitializePlatnosci(ref context);
            InitializeWykladowcy(ref context);
            InitializeWykladowcyLogowanie(ref context);
            InitializeZajecia(ref context);
            InitializeStudenciOceny(ref context);

            context.SaveChanges();
        }

        public static void InitializeGrupy(ref DziekanatContext context)
        {
            if (context.Grupy.Any())
                return;

            Grupa[] grupy = new Grupa[]
            {
                new Grupa{ GrupaNr = "Gr1IS"},
                new Grupa{ GrupaNr = "Gr2IS"},
                new Grupa{ GrupaNr = "Gr3IS"}
            };

            foreach (Grupa g in grupy)
                context.Grupy.Add(g);

            context.SaveChanges();
        }

        public static void InitializeStudenci(ref DziekanatContext context)
        {
            if (context.Studenci.Any())
                return;

            Student[] studenci = new Student[]
            {
                new Student{ NumerIndeksu = "1001", Imie = "Adam",    Nazwisko = "Nowak", DataUrodzenia = DateTime.Parse("10.12.1999"), PESEL = "12345678910", GrupaNr = "Gr1IS" },
                new Student{ NumerIndeksu = "1002", Imie = "Andrzej", Nazwisko = "Duda",  DataUrodzenia = DateTime.Parse("15.10.1999"), PESEL = "12345678911", GrupaNr = "Gr3IS" },
                new Student{ NumerIndeksu = "1003", Imie = "Anna",    Nazwisko = "Rożek", DataUrodzenia = DateTime.Parse("19.02.1999"), PESEL = "12345678912", GrupaNr = "Gr2IS" },
                new Student{ NumerIndeksu = "1007", Imie = "Justyna", Nazwisko = "Dzik",  DataUrodzenia = DateTime.Parse("25.07.2000"), PESEL = "12345678913", GrupaNr = "Gr2IS" },
                new Student{ NumerIndeksu = "1010", Imie = "Michał",  Nazwisko = "Lis",   DataUrodzenia = DateTime.Parse("10.05.1997"), PESEL = "12345678914", GrupaNr = "Gr1IS" }
            };

            foreach (Student s in studenci)
                context.Studenci.Add(s);

            context.SaveChanges();
        }

        public static void InitializeStudenciLogowanie(ref DziekanatContext context)
        {
            if (context.StudenciLogowanie.Any())
                return;

            StudentLogowanie[] studenciLogowanie = new StudentLogowanie[]
            {
                new StudentLogowanie{ StudentID = 1, Login = "AdamNowak",   Haslo = "12345678910" },
                new StudentLogowanie{ StudentID = 2, Login = "AndrzejDuda", Haslo = "12345678911" },
                new StudentLogowanie{ StudentID = 3, Login = "AnnaRozek",   Haslo = "12345678912" },
                new StudentLogowanie{ StudentID = 4, Login = "JustynaDzik", Haslo = "12345678913" },
                new StudentLogowanie{ StudentID = 5, Login = "MichalLis",   Haslo = "12345678914" }
            };

            foreach (StudentLogowanie sl in studenciLogowanie)
                context.StudenciLogowanie.Add(sl);

            context.SaveChanges();
        }

        public static void InitializePlatnosci(ref DziekanatContext context)
        {
            if (context.Platnosci.Any())
                return;

            Platnosc[] platnosci = new Platnosc[]
            {
                new Platnosc{ StudentID = 3, Kwota = 3600, DataPlatnosci = DateTime.Parse("05.10.2020") },
                new Platnosc{ StudentID = 1, Kwota = 3600, DataPlatnosci = DateTime.Parse("08.10.2020") },
                new Platnosc{ StudentID = 5, Kwota = 3600, DataPlatnosci = DateTime.Parse("10.10.2020") },
                new Platnosc{ StudentID = 4, Kwota = 3600, DataPlatnosci = DateTime.Parse("10.10.2020") },
                new Platnosc{ StudentID = 2, Kwota = 3600, DataPlatnosci = DateTime.Parse("12.10.2020") }
            };

            foreach (Platnosc p in platnosci)
                context.Platnosci.Add(p);

            context.SaveChanges();
        }

        public static void InitializeWykladowcy(ref DziekanatContext context)
        {
            if (context.Wykladowcy.Any())
                return;
            

            Wykladowca[] wykladowcy = new Wykladowca[]
            {
                new Wykladowca{ Imie = "Mateusz",   Nazwisko = "Adamski",      StopienNaukowy = "Profesor", PESEL = "12345678915" },
                new Wykladowca{ Imie = "Arkadiusz", Nazwisko = "Kędra",        StopienNaukowy = "Doktor",   PESEL = "12345678916" },
                new Wykladowca{ Imie = "Wojciech",  Nazwisko = "Nowak",        StopienNaukowy = "Doktor",   PESEL = "12345678917" },
                new Wykladowca{ Imie = "Grzegorz",  Nazwisko = "Olkowicz",     StopienNaukowy = "Magister", PESEL = "12345678918" },
                new Wykladowca{ Imie = "Janusz",    Nazwisko = "Kłos",         StopienNaukowy = "Magister", PESEL = "12345678919" },
                new Wykladowca{ Imie = "Jeży",      Nazwisko = "Królik",       StopienNaukowy = "Profesor", PESEL = "12345678920" },
                new Wykladowca{ Imie = "Jarosław",  Nazwisko = "Parafiańczyk", StopienNaukowy = "Profesor", PESEL = "12345678921" },
                new Wykladowca{ Imie = "Emil",      Nazwisko = "Pawlicz",      StopienNaukowy = "Profesor", PESEL = "12345678922" }
            };

            foreach (Wykladowca w in wykladowcy)
                context.Wykladowcy.Add(w);

            context.SaveChanges();
        }

        public static void InitializeWykladowcyLogowanie(ref DziekanatContext context)
        {
            if (context.WykladowcyLogowanie.Any())
                return;
            

            WykladowcaLogowanie[] wykladowcyLogowanie = new WykladowcaLogowanie[]
            {
                new WykladowcaLogowanie{ WykladowcaID = 1, Login = "MateuszAdamski",       Haslo = "12345678915" },
                new WykladowcaLogowanie{ WykladowcaID = 2, Login = "ArkadiuszKedra",       Haslo = "12345678916" },
                new WykladowcaLogowanie{ WykladowcaID = 3, Login = "WojciechNowak",        Haslo = "12345678917" },
                new WykladowcaLogowanie{ WykladowcaID = 4, Login = "GrzegorzOlkowicz",     Haslo = "12345678918" },
                new WykladowcaLogowanie{ WykladowcaID = 5, Login = "JanuszKlos",           Haslo = "12345678919" },
                new WykladowcaLogowanie{ WykladowcaID = 6, Login = "JezyKrolik",           Haslo = "12345678920" },
                new WykladowcaLogowanie{ WykladowcaID = 7, Login = "JaroslawParafianczyk", Haslo = "12345678921" },
                new WykladowcaLogowanie{ WykladowcaID = 8, Login = "EmilPawlicz",          Haslo = "12345678922" }
            };

            foreach (WykladowcaLogowanie wl in wykladowcyLogowanie)
                context.WykladowcyLogowanie.Add(wl);

            context.SaveChanges();
        }

        public static void InitializeZajecia(ref DziekanatContext context)
        {
            if (context.PlanZajec.Any())
                return;

            Zajecia[] zajecia = new Zajecia[]
            {
                new Zajecia{ NazwaZajec = "Programowanie .NET",    TerminZajec = DateTime.Parse("11.01.2022 10:00:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ NazwaZajec = "Programowanie C#",      TerminZajec = DateTime.Parse("11.01.2022 11:45:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ NazwaZajec = "Programowanie Java",    TerminZajec = DateTime.Parse("11.01.2022 13:15:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ NazwaZajec = "Bazy danych",           TerminZajec = DateTime.Parse("12.01.2022 10:00:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ NazwaZajec = "Wzorce projektowe",     TerminZajec = DateTime.Parse("13.01.2022 10:00:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ NazwaZajec = "Zarządzanie projektem", TerminZajec = DateTime.Parse("13.01.2022 11:45:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ NazwaZajec = "UX",                    TerminZajec = DateTime.Parse("13.01.2022 13:15:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ NazwaZajec = "Microsoft",             TerminZajec = DateTime.Parse("13.01.2022 15:00:00"), GrupaNr = "Gr1IS" },

                new Zajecia{ NazwaZajec = "Programowanie .NET",    TerminZajec = DateTime.Parse("11.01.2022 11:45:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ NazwaZajec = "Programowanie C#",      TerminZajec = DateTime.Parse("11.01.2022 13:15:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ NazwaZajec = "Programowanie Java",    TerminZajec = DateTime.Parse("11.01.2022 10:00:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ NazwaZajec = "Bazy danych",           TerminZajec = DateTime.Parse("12.01.2022 11:45:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ NazwaZajec = "Wzorce projektowe",     TerminZajec = DateTime.Parse("12.01.2022 10:00:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ NazwaZajec = "Zarządzanie projektem", TerminZajec = DateTime.Parse("12.01.2022 13:15:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ NazwaZajec = "UX",                    TerminZajec = DateTime.Parse("12.01.2022 15:00:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ NazwaZajec = "Microsoft",             TerminZajec = DateTime.Parse("13.01.2022 13:15:00"), GrupaNr = "Gr2IS" },

                new Zajecia{ NazwaZajec = "Programowanie .NET",    TerminZajec = DateTime.Parse("11.01.2022 13:15:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ NazwaZajec = "Programowanie C#",      TerminZajec = DateTime.Parse("11.01.2022 10:00:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ NazwaZajec = "Programowanie Java",    TerminZajec = DateTime.Parse("11.01.2022 11:45:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ NazwaZajec = "Bazy danych",           TerminZajec = DateTime.Parse("12.01.2022 13:15:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ NazwaZajec = "Wzorce projektowe",     TerminZajec = DateTime.Parse("14.01.2022 10:00:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ NazwaZajec = "Zarządzanie projektem", TerminZajec = DateTime.Parse("14.01.2022 11:45:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ NazwaZajec = "UX",                    TerminZajec = DateTime.Parse("14.01.2022 13:15:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ NazwaZajec = "Microsoft",             TerminZajec = DateTime.Parse("14.01.2022 15:00:00"), GrupaNr = "Gr3IS" }
            };

            foreach (Zajecia z in zajecia)
                context.PlanZajec.Add(z);

            context.SaveChanges();
        }

        public static void InitializeStudenciOceny(ref DziekanatContext context)
        {
            if (context.StudenciOceny.Any())
                return;

            StudentOceny[] studenciOceny = new StudentOceny[]
            {
                new StudentOceny{ StudentID = 1, ZajeciaID = 3,  Ocena = 4.0f },
                new StudentOceny{ StudentID = 1, ZajeciaID = 4,  Ocena = 4.5f },
                new StudentOceny{ StudentID = 2, ZajeciaID = 19, Ocena = 3.0f }
            };

            foreach (StudentOceny so in studenciOceny)
                context.StudenciOceny.Add(so);

            context.SaveChanges();
        }
    }
}
