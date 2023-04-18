using System.Net.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        Osobe osoba = new Osobe();
        Console.WriteLine("Unesite spol: (za musko M ili m za zensko Z ili z: ");
        osoba.spol = Console.ReadLine();

        Console.WriteLine("Unesite godine:");
        osoba.godine = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Da li ste dijabeticar? (DA/da/NE/ne)");
        osoba.dijabeticar = Console.ReadLine();

        Console.WriteLine("Unesite SBP: ");
        osoba.SBP = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Da li ste pusac? (DA/da/NE/ne");
        osoba.pusac = Console.ReadLine();

        Console.WriteLine("Unesite holesterol: ");
        osoba.holesterol = Double.Parse(Console.ReadLine()) ;



            if (osoba.spol == "M" || osoba.spol == "m")
            {
                Console.WriteLine(osoba.RacunajERICEmuskarca());
            }
            else if (osoba.spol == "Z" || osoba.spol == "z")
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
            // mild uslovi za muskarca izmedju 50 i 59 godina
            if (godine >= 50 && godine <= 59)
            {
                if (SBP >= 180 && dijabeticar == "NE" || dijabeticar == "ne" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP < 140 && dijabeticar == "DA" || dijabeticar == "da" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP < 140 && dijabeticar == "DA" || dijabeticar == "da" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "DA" || pusac == "da")
                {
                    return "mild";
                }
                else if (SBP >= 140 || SBP < 180 && dijabeticar == "NE" || dijabeticar == "ne" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP < 140 && dijabeticar == "NE" || dijabeticar == "ne" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "DA" || pusac == "da")
                {
                    return "mild";
                }
                
            }
            // mild uslovi za muskarca izmedju 40 i 49 godina
            if (godine >= 40 && godine <= 49)
            {
                if (SBP >= 180 && dijabeticar == "DA" || dijabeticar == "da" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP >=160 || SBP <=180 && dijabeticar == "DA" || dijabeticar == "da" &&  holesterol >= 6.5 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP >= 140 || SBP <= 180 && dijabeticar == "DA" || dijabeticar == "da" &&  holesterol >= 6.5 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP >= 180 && dijabeticar == "NE" || dijabeticar == "ne" && holesterol >= 5.2 && pusac == "DA" || pusac == "da")
                {
                    return "mild";
                }
                else if (SBP >= 160 || SBP <= 180 && dijabeticar == "NE" || dijabeticar == "ne" && holesterol >= 6.5 && pusac == "DA" || pusac == "da")
                {
                    return "mild";
                }
            }
           return "Pogresno ste unijeli parametre";
        }


        public string RacunajERICEzene()
        {
            // mild razina za zene izmedju 60 i 69 godina
            if (godine >= 60 && godine <= 69)
            {
                if (SBP <180 && dijabeticar == "NE" || dijabeticar == "ne" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else 
                {
                    return "Ne spada te ovoj skupini";
                }
               
            }
            // mild razina za zene izmedju 50 i 59 godina
            if (godine >=50 && godine <= 59)
            { 
                if (SBP < 180  && dijabeticar == "DA" || dijabeticar == "da" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP < 180  && dijabeticar == "NE" || dijabeticar == "ne" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "NE" || pusac == "ne")
                {
                    return "mild";
                }
                else if (SBP < 180 && dijabeticar == "NE" || dijabeticar == "ne" && holesterol < 5.2 || holesterol >= 7.8 && pusac == "DA" || pusac == "da")
                {
                    return "mild";
                }
            }

            return "Pogresno ste unijeli parametre";
    }
    }


}