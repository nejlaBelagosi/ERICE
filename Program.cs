using System.Linq.Expressions;
using System.Net.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        Osobe osoba = new Osobe();
        Console.WriteLine("Unesite spol: (za musko M ili za zensko Z: ");
        osoba.spol = Console.ReadLine().ToUpper();

        Console.WriteLine("Unesite godine:");
        osoba.godine = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Da li ste dijabeticar?");
        osoba.dijabeticar = Console.ReadLine().ToUpper();

        Console.WriteLine("Unesite SBP: ");
        osoba.SBP = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Da li ste pusac?");
        osoba.pusac = Console.ReadLine().ToUpper();

        Console.WriteLine("Unesite holesterol: ");
        osoba.holesterol = Double.Parse(Console.ReadLine());

        if (osoba.spol == "M")
        {
            Console.WriteLine(osoba.RacunajERICEmuskarca());
        }
        else if (osoba.spol == "Z")
        {
            Console.WriteLine(osoba.RacunajERICEzene());
        }
    }

    public class Osobe
    {
        public string spol;
        public int godine;
        public double holesterol;
        public string dijabeticar;
        public int SBP;
        public string pusac;

        public string RacunajERICEmuskarca()
        {
            //VERY HIGH
            if ((SBP >= 140 && SBP <= 160 && dijabeticar == "DA" && godine >= 70 && godine <= 79) ||
                (SBP >= 140 && SBP <= 160 && dijabeticar == "NE" && godine >= 70 && godine <= 79 && pusac == "DA") ||
                (SBP >= 180 && dijabeticar == "DA" && godine >= 60 && godine <= 69 && pusac == "DA") ||
                (SBP >= 160 && SBP <= 180 && dijabeticar == "DA" && holesterol > 6.5 && pusac == "DA") ||
                (godine >= 80))
            {
                return "Very high";
            }

            //HIGH
            if (godine >= 70 && godine <= 79)
            {
                if ((SBP >= 140 && dijabeticar == "NE" && pusac == "NE") ||
                   (SBP < 140 && dijabeticar == "DA") ||
                   (SBP < 140 && dijabeticar == "NE" && pusac == "DA"))
                {
                    return "high";
                }
                return "Pogresno ste unijeli parametre";
            }

            if (godine >= 60 && godine <= 69)
            {
                if (((SBP >= 140) && dijabeticar == "DA" && pusac == "NE") ||
                    (SBP > 140 && SBP < 180 && dijabeticar == "DA" && pusac == "DA" && holesterol < 6.5) ||
                    (SBP > 140 && SBP < 160 && dijabeticar == "DA" && pusac == "DA" && holesterol > 6.5) ||
                    (SBP >= 140 && dijabeticar == "NE" && pusac == "DA"))
                {
                    return "high";
                }
            }

            //MODERATE HIGH
            if (godine >= 60 && godine <= 69)
            {
                if ((SBP >= 140 && dijabeticar == "NE" && pusac == "NE") ||
                   (SBP < 140 && dijabeticar == "DA" && pusac == "NE" && holesterol >= 5.2 && holesterol <= 6.4) ||
                   (SBP < 140 && dijabeticar == "DA" && pusac == "DA") ||
                   (SBP < 140 && dijabeticar == "NE" && pusac == "DA" && holesterol > 5.2))
                {
                    return "moderate high";
                }
            }

            if (godine >= 70 && godine <= 79)
            {
                if (SBP < 140 && dijabeticar == "NE" && pusac == "NE")
                {
                    return "moderate high";
                }
            }

            if (godine >= 50 && godine <= 59)
            {
                if (SBP >= 160 && dijabeticar == "DA" && pusac == "DA")
                {
                    return "moderate high";
                }
            }

            //MODERATE
            if (godine >= 60 && godine <= 69)
            {
                if ((SBP < 140 && dijabeticar == "DA" && pusac == "NE" && holesterol < 5.2) ||
                    (SBP < 140 && dijabeticar == "NE" && pusac == "NE") ||
                    (SBP < 140 && dijabeticar == "NE" && pusac == "DA" && holesterol < 5.2))
                {
                    return "moderate";
                }
            }

            if (godine >= 50 && godine <= 59)
            {
                if ((SBP >= 140 && dijabeticar == "DA" && pusac == "NE") ||
                    (SBP > 140 && SBP < 160 && dijabeticar == "DA" && pusac == "DA") ||
                    (SBP < 140 && dijabeticar == "DA" && pusac == "DA" && holesterol > 5.2 && holesterol < 7.7) ||
                    (SBP >= 180 && dijabeticar == "NE" && pusac == "NE" && holesterol > 5.2) ||
                    (SBP >= 140 && dijabeticar == "NE" && pusac == "DA"))
                {
                    return "moderate";
                }
            }
            //MILD
            if (godine >= 50 && godine <= 59)
            {
                if ((SBP >= 180 && dijabeticar == "NE" && pusac == "NE") ||
                    (SBP < 140 && dijabeticar == "DA" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "DA") ||
                    (SBP < 140 && dijabeticar == "DA" && pusac == "NE") ||
                    (SBP >= 140 && SBP < 180 && dijabeticar == "NE" && pusac == "NE") ||
                    (SBP < 140 && dijabeticar == "NE" && pusac == "DA"))
                {
                    return "mild";
                }
            }

            if (godine >= 40 && godine <= 49)
            {
                if ((SBP >= 180 && dijabeticar == "DA") ||
                    (SBP >= 160 && SBP <= 180 && dijabeticar == "DA" && holesterol >= 6.5 && pusac == "NE") ||
                    (SBP >= 140 && SBP <= 180 && dijabeticar == "DA" && pusac == "DA") ||
                    (SBP >= 180 && dijabeticar == "NE" && holesterol >= 5.2 && pusac == "DA") ||
                    (SBP >= 160 && SBP <= 180 && dijabeticar == "NE" && holesterol >= 6.5 && pusac == "DA"))
                {
                    return "mild";
                }
            }

            //LOW 
            if (godine >= 40 && godine <= 49)
            {
                if ((SBP >= 160 && SBP <= 180 && dijabeticar == "DA" && holesterol < 6.5 && pusac == "NE") ||
                    (SBP < 160 && dijabeticar == "DA" && pusac == "NE") ||
                    (SBP < 140 && dijabeticar == "DA" && pusac == "DA") ||
                    (SBP >= 180 && dijabeticar == "NE" && holesterol < 5.2 && pusac == "DA") ||
                    (SBP >= 160 && SBP <= 180 && dijabeticar == "NE" && holesterol < 6.6 && pusac == "DA") ||
                    (SBP < 160 && dijabeticar == "NE" && pusac == "DA"))
                {
                    return "low";
                }
            }

            if (godine >= 30 && godine <= 49)
            {
                if (dijabeticar == "NE" && pusac == "NE")
                {
                    return "low";
                }

                if (godine >= 30 && godine <= 39)
                {
                    if ((dijabeticar == "DA") ||
                        (dijabeticar == "NE" && pusac == "DA"))
                    {
                        return "low";
                    }
                }
            }
            return "Pogresno ste unijeli parametre";
        }

        public string RacunajERICEzene()
        {
            //VERY HIGH
            if ((godine >= 80) ||
                (godine >= 70 && godine <= 79 && SBP >= 180 && dijabeticar == "DA") ||
                (godine >= 70 && godine <= 79 && SBP >= 180 && dijabeticar == "NE" && pusac == "DA") ||
                (godine >= 70 && godine <= 79 && dijabeticar == "DA" && pusac == "DA"))
            {
                return "Very high";
            }

            if (godine >= 70 && godine <= 80)
            {
                if ((dijabeticar == "DA" && pusac == "DA") ||
                    (dijabeticar == "NE" && pusac == "NE" && godine >= 80) ||
                    (dijabeticar == "DA" && pusac == "NE" && godine >= 79))
                {
                    return "Very high";
                }
            }

            //HIGH
            if (godine >= 70 && godine <= 79)
            {
                if ((SBP >= 180 && dijabeticar == "NE" && pusac == "NE") ||
                    (SBP < 180 && dijabeticar == "DA" && pusac == "NE") ||
                    (SBP < 180 && dijabeticar == "NE" && pusac == "DA"))
                {
                    return "high";
                }

                else if (godine >= 60 && godine <= 69)
                {
                    if ((SBP >= 180 && dijabeticar == "DA") ||
                        (SBP >= 180 && dijabeticar == "NE" && pusac == "DA"))
                    {
                        return "high";
                    }
                    return "Pogresno ste unijeli parametre";
                }
                return "Pogresno ste unijeli parametre";
            }
            //MODERATE HIGH
            if ((SBP >= 140 && SBP <= 180 && dijabeticar == "NE" && pusac == "NE" && (godine >= 70 && godine <= 79)) ||
                (SBP < 180 && dijabeticar == "DA" && pusac == "DA" && (godine >= 60 && godine <= 69)) ||
                 (SBP >= 180 && dijabeticar == "DA" && pusac == "DA" && (godine >= 50 && godine <= 59)))
            {
                return "Moderate-high";
            }

            //MODERATE
            if (godine >= 69 && godine <= 69)
            {
                if ((SBP >= 180 && dijabeticar == "NE" && pusac == "NE") ||
                    (SBP < 180 && dijabeticar == "DA" && pusac == "NE"))
                {
                    return "moderate";
                }
                return "Pogresno ste unijeli parametre";
            }
            else if (godine >= 50 && godine <= 59)
            {
                if ((SBP < 180 && dijabeticar == "NE" && pusac == "DA") ||
                    (SBP < 180 && dijabeticar == "DA" && pusac == "DA") ||
                    (SBP >= 180 && dijabeticar == "NE" && pusac == "DA") ||
                    (SBP >= 180 && dijabeticar == "DA" && pusac == "NE"))
                {
                    return "moderate";
                }
            }
            //MILD
            if (godine >= 60 && godine <= 69)
            {
                if (SBP < 180 && dijabeticar == "NE" && pusac == "NE")
                {
                    return "mild";
                }
            }
            if (godine >= 50 && godine <= 59)
            {
                if ((SBP < 180 && dijabeticar == "DA" && pusac == "NE") ||
                    (SBP < 180 && dijabeticar == "NE" && pusac == "NE") ||
                    (SBP < 180 && dijabeticar == "NE" && pusac == "DA"))
                {
                    return "mild";
                }
            }
            //LOW
            if (godine >= 30 && godine <= 49)
            {
                return "low";
            }
            return "Pogresno ste unijeli parametre";
        }
    }
}