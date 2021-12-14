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

            InitializeGrupy(context);
            InitializeStudenci(context);
            InitializeStudenciLogowanie(context);
            InitializeFinanse(context);
            InitializeWykladowcy(context);
            InitializeWykladowcyLogowanie(context);
            InitializeZajecia(context);
            InitializeStudenciOceny(context);
        }

        public static void InitializeGrupy(DziekanatContext context)
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

        public static void InitializeStudenci(DziekanatContext context)
        {
            if (context.Studenci.Any())
                return;

            Student[] studenci = new Student[]
            {
                new Student{ StudentID = 1, NumerIndeksu = "1001", Imie = "Adam",    Nazwisko = "Nowak", DataUrodzenia = DateTime.Parse("10.12.1999"), PESEL = "12345678910", GrupaNr = "Gr1IS" },
                new Student{ StudentID = 2, NumerIndeksu = "1002", Imie = "Andrzej", Nazwisko = "Duda",  DataUrodzenia = DateTime.Parse("15.10.1999"), PESEL = "12345678911", GrupaNr = "Gr3IS" },
                new Student{ StudentID = 3, NumerIndeksu = "1003", Imie = "Anna",    Nazwisko = "Rożek", DataUrodzenia = DateTime.Parse("19.02.1999"), PESEL = "12345678912", GrupaNr = "Gr2IS" },
                new Student{ StudentID = 4, NumerIndeksu = "1007", Imie = "Justyna", Nazwisko = "Dzik",  DataUrodzenia = DateTime.Parse("25.07.2000"), PESEL = "12345678913", GrupaNr = "Gr2IS" },
                new Student{ StudentID = 5, NumerIndeksu = "1010", Imie = "Michał",  Nazwisko = "Lis",   DataUrodzenia = DateTime.Parse("10.05.1997"), PESEL = "12345678914", GrupaNr = "Gr1IS" }
            };

            foreach (Student s in studenci)
                context.Studenci.Add(s);

            context.SaveChanges();
        }

        public static void InitializeStudenciLogowanie(DziekanatContext context)
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

        public static void InitializeFinanse(DziekanatContext context)
        {
            if (context.Finanse.Any())
                return;

            Finanse[] finanse = new Finanse[]
            {
                new Finanse{ PlatnoscID = 1, StudentID = 3, Kwota = 3600, DataPlatnosci = DateTime.Parse("05.10.2020") },
                new Finanse{ PlatnoscID = 2, StudentID = 1, Kwota = 3600, DataPlatnosci = DateTime.Parse("08.10.2020") },
                new Finanse{ PlatnoscID = 3, StudentID = 5, Kwota = 3600, DataPlatnosci = DateTime.Parse("10.10.2020") },
                new Finanse{ PlatnoscID = 4, StudentID = 4, Kwota = 3600, DataPlatnosci = DateTime.Parse("10.10.2020") },
                new Finanse{ PlatnoscID = 5, StudentID = 2, Kwota = 3600, DataPlatnosci = DateTime.Parse("12.10.2020") }
            };

            foreach (Finanse f in finanse)
                context.Finanse.Add(f);

            context.SaveChanges();
        }

        public static void InitializeWykladowcy(DziekanatContext context)
        {
            if (context.Wykladowcy.Any())
                return;
            

            Wykladowca[] wykladowcy = new Wykladowca[]
            {
                new Wykladowca{ WykladowcaID = 1, Imie = "Mateusz",   Nazwisko = "Adamski",      StopienNaukowy = "Profesor", PESEL = "12345678915" },
                new Wykladowca{ WykladowcaID = 2, Imie = "Arkadiusz", Nazwisko = "Kędra",        StopienNaukowy = "Doktor",   PESEL = "12345678916" },
                new Wykladowca{ WykladowcaID = 3, Imie = "Wojciech",  Nazwisko = "Nowak",        StopienNaukowy = "Doktor",   PESEL = "12345678917" },
                new Wykladowca{ WykladowcaID = 4, Imie = "Grzegorz",  Nazwisko = "Olkowicz",     StopienNaukowy = "Magister", PESEL = "12345678918" },
                new Wykladowca{ WykladowcaID = 5, Imie = "Janusz",    Nazwisko = "Kłos",         StopienNaukowy = "Magister", PESEL = "12345678919" },
                new Wykladowca{ WykladowcaID = 6, Imie = "Jeży",      Nazwisko = "Królik",       StopienNaukowy = "Profesor", PESEL = "12345678920" },
                new Wykladowca{ WykladowcaID = 7, Imie = "Jarosław",  Nazwisko = "Parafiańczyk", StopienNaukowy = "Profesor", PESEL = "12345678921" },
                new Wykladowca{ WykladowcaID = 8, Imie = "Emil",      Nazwisko = "Pawlicz",      StopienNaukowy = "Profesor", PESEL = "12345678922" }
            };

            foreach (Wykladowca w in wykladowcy)
                context.Wykladowcy.Add(w);

            context.SaveChanges();
        }

        public static void InitializeWykladowcyLogowanie(DziekanatContext context)
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

        public static void InitializeZajecia(DziekanatContext context)
        {
            if (context.Zajecia.Any())
                return;

            Zajecia[] zajecia = new Zajecia[]
            {
                new Zajecia{ ZajeciaID = 1,  NazwaZajec = "Programowanie .NET",    TerminZajec = DateTime.Parse("11.01.2022 10:00:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ ZajeciaID = 2,  NazwaZajec = "Programowanie C#",      TerminZajec = DateTime.Parse("11.01.2022 11:45:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ ZajeciaID = 3,  NazwaZajec = "Programowanie Java",    TerminZajec = DateTime.Parse("11.01.2022 13:15:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ ZajeciaID = 4,  NazwaZajec = "Bazy danych",           TerminZajec = DateTime.Parse("12.01.2022 10:00:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ ZajeciaID = 5,  NazwaZajec = "Wzorce projektowe",     TerminZajec = DateTime.Parse("13.01.2022 10:00:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ ZajeciaID = 6,  NazwaZajec = "Zarządzanie projektem", TerminZajec = DateTime.Parse("13.01.2022 11:45:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ ZajeciaID = 7,  NazwaZajec = "UX",                    TerminZajec = DateTime.Parse("13.01.2022 13:15:00"), GrupaNr = "Gr1IS" },
                new Zajecia{ ZajeciaID = 8,  NazwaZajec = "Microsoft",             TerminZajec = DateTime.Parse("13.01.2022 15:00:00"), GrupaNr = "Gr1IS" },

                new Zajecia{ ZajeciaID = 9,  NazwaZajec = "Programowanie .NET",    TerminZajec = DateTime.Parse("11.01.2022 11:45:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ ZajeciaID = 10, NazwaZajec = "Programowanie C#",      TerminZajec = DateTime.Parse("11.01.2022 13:15:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ ZajeciaID = 11, NazwaZajec = "Programowanie Java",    TerminZajec = DateTime.Parse("11.01.2022 10:00:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ ZajeciaID = 12, NazwaZajec = "Bazy danych",           TerminZajec = DateTime.Parse("12.01.2022 11:45:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ ZajeciaID = 13, NazwaZajec = "Wzorce projektowe",     TerminZajec = DateTime.Parse("12.01.2022 10:00:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ ZajeciaID = 14, NazwaZajec = "Zarządzanie projektem", TerminZajec = DateTime.Parse("12.01.2022 13:15:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ ZajeciaID = 15, NazwaZajec = "UX",                    TerminZajec = DateTime.Parse("12.01.2022 15:00:00"), GrupaNr = "Gr2IS" },
                new Zajecia{ ZajeciaID = 16, NazwaZajec = "Microsoft",             TerminZajec = DateTime.Parse("13.01.2022 13:15:00"), GrupaNr = "Gr2IS" },

                new Zajecia{ ZajeciaID = 17, NazwaZajec = "Programowanie .NET",    TerminZajec = DateTime.Parse("11.01.2022 13:15:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ ZajeciaID = 18, NazwaZajec = "Programowanie C#",      TerminZajec = DateTime.Parse("11.01.2022 10:00:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ ZajeciaID = 19, NazwaZajec = "Programowanie Java",    TerminZajec = DateTime.Parse("11.01.2022 11:45:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ ZajeciaID = 20, NazwaZajec = "Bazy danych",           TerminZajec = DateTime.Parse("12.01.2022 13:15:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ ZajeciaID = 21, NazwaZajec = "Wzorce projektowe",     TerminZajec = DateTime.Parse("14.01.2022 10:00:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ ZajeciaID = 22, NazwaZajec = "Zarządzanie projektem", TerminZajec = DateTime.Parse("14.01.2022 11:45:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ ZajeciaID = 23, NazwaZajec = "UX",                    TerminZajec = DateTime.Parse("14.01.2022 13:15:00"), GrupaNr = "Gr3IS" },
                new Zajecia{ ZajeciaID = 24, NazwaZajec = "Microsoft",             TerminZajec = DateTime.Parse("14.01.2022 15:00:00"), GrupaNr = "Gr3IS" }
            };

            foreach (Zajecia z in zajecia)
                context.Zajecia.Add(z);

            context.SaveChanges();
        }

        public static void InitializeStudenciOceny(DziekanatContext context)
        {
            if (context.StudentOceny.Any())
                return;

            StudentOceny[] studenciOceny = new StudentOceny[]
            {
                new StudentOceny{ StudentID = 1, ZajeciaID = 3,  Ocena = 4.0f },
                new StudentOceny{ StudentID = 1, ZajeciaID = 4,  Ocena = 4.5f },
                new StudentOceny{ StudentID = 2, ZajeciaID = 19, Ocena = 3.0f }
            };

            foreach (StudentOceny so in studenciOceny)
                context.StudentOceny.Add(so);

            context.SaveChanges();
        }
    }
}
