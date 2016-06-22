using System;
using System.Collections.Generic;

namespace VarekartotekApplication
{
    // definition af "Hoved-programmet" (data og metoder der findes i hovedprogrammet)
    public class VarekartotekConsoleApplication
    {
        // Application objectets memory (datafelter)
        List<Vare> varesamling;

        // opstarts metoden (constructor)
        public VarekartotekConsoleApplication()
        {
            this.varesamling = new List<Vare>();     // opret tom varesamling
            this.OpretTestVarer();                   // fyld data i 

            bool keepRunning = true;
            do
            {
                Console.Clear();
                UdskrivHovedmenu();
                int menuValg = MenuValg();
                switch(menuValg)
                {
                    case 0:
                        keepRunning = false;
                        break;

                    case 1:
                        this.UdskrivAlleVarer();    // udskriv
                        Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                        Console.ReadKey();
                        break;

                    case 2:
                        VareHandling("FindEnVare");
                        break;

                    case 3:
                        VareHandling("RegistrerSalgAfEnVare");
                        break;

                    case 4:
                        VareHandling("RegistrerIndkøbAfEnVare");
                        break;

                    case -1:
                        Console.WriteLine("Indtast venligst et tal");
                        Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                        Console.ReadKey();
                        break;
                    
                    default:
                        Console.WriteLine("Indtast venligst et gyldigt tal");
                        Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                        Console.ReadKey();
                        break;
                }
            } while (keepRunning);
        }

        private void UdskrivHovedmenu()
        {
            Console.WriteLine("Hovedmenu");
            Console.WriteLine("0. Afslut program");
            Console.WriteLine("1. Udskriv alle varer");
            Console.WriteLine("2. Find en vare");
            Console.WriteLine("3. Registrer salg af en vare");
            Console.WriteLine("4. Registrer indkøb af en vare");
        }

        private void VareHandling(string handling)
        {
            bool keepRunning = true;
            do
            {
                Console.Clear();
                VarenrMenu();
                int menuValg = MenuValg();

                if (menuValg == 0)
                    keepRunning = false;
                else if (menuValg == -1)
                {
                    Console.WriteLine("Indtast venligst et tal");
                    Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                    Console.ReadKey();
                }
                else
                {
                    Vare valgtVare = Vare.FindEnVareMedVarenr(menuValg, varesamling);
                    if (valgtVare == null)
                    {
                        Console.WriteLine("Der eksisterer ikke nogen vare med det indtastede varenr.");
                        Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                        Console.ReadKey();
                    }
                    else if (handling == "FindEnVare")
                    {
                        UdskrivEnVare(valgtVare);
                        Console.WriteLine("\nTryk på en vilkårlig tast for at fortsætte...");
                        Console.ReadKey();
                        keepRunning = false;
                    }
                    else if (handling == "RegistrerSalgAfEnVare" || handling == "RegistrerIndkøbAfEnVare")
                    {
                        if (RegistrerHandling(valgtVare, handling))
                        {
                            keepRunning = false;
                        }
                    }
                }
            } while (keepRunning);
        }

        private void VarenrMenu()
        {
            Console.WriteLine("0. Tilbage");
            Console.Write("Indtast venligst et varenr[xxxx]: ");
        }

        private bool RegistrerHandling(Vare vare, string handling)
        {
            bool keepRunning = true;
            bool RegistreringGennemført = false;
            do
            {
                Console.Clear();
                VareAntalMenu();
                int menuValg = MenuValg();
                if (menuValg == 0)
                    keepRunning = false;
                else if (menuValg == -1)
                {
                    Console.WriteLine("Indtast venligst et tal");
                    Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                    Console.ReadKey();
                }
                else
                {
                    if (handling == "RegistrerSalgAfEnVare")
                    {
                        vare.RegistrerVarerSolgt(menuValg);
                        UdskrivRegistreringAfSalg(menuValg, vare);
                    }
                    else if (handling == "RegistrerIndkøbAfEnVare")
                    {
                        vare.RegistrerVarerIndkøbt(menuValg);
                        UdskrivRegistreringAfIndkøb(menuValg, vare);
                    }
                    Console.WriteLine("Tryk på en vilkårlig tast for at fortsætte...");
                    Console.ReadKey();
                    keepRunning = false;
                    RegistreringGennemført = true;
                }
            } while (keepRunning);
            return RegistreringGennemført;
        }

        private void VareAntalMenu()
        {
            Console.WriteLine("0. Tilbage");
            Console.Write("Indtast venligst et antal af den valgte vare: ");
        }

        private int MenuValg()
        {
            int valg = -1;
            try
            {
                valg = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                valg = -1;
                return valg;
            }
            return valg;
        }

        // metode der opretter test varer
        private void OpretTestVarer()
        {
            varesamling.Add(new Vare(1001, "A4 blok ternet med huller", "Blok", 10, 3, 10 + 3, 13, 3.98f, 2.56f));
            varesamling.Add(new Vare(1002, "A4 blok linieret med huller", "Blok", 20, 11, 20+11, 20, 3.88f, 2.73f));
            varesamling.Add(new Vare(1003, "Blyant Viking 400x2", "Æske", 110, 36, 110+36, 100, 0.64f, 0.45f));
            varesamling.Add(new Vare(1004, "Lenovo bærbar", "Styk", 2, 5, 2+5, 3, 4999f, 1500f));
            varesamling.Add(new Vare(1005, "Blyantspidser", "Styk", 57, 2, 50, 57+2, 9.5f, 0.53f));
        }

        // metode der udskriver en oversigt over alle varer i samlingen
        private void UdskrivAlleVarer()
        {
            double totalSalgsværdi = 0;
            double totalIndkøbsværdi = 0;

            Console.WriteLine("Vare oversigt");
            foreach (Vare vare in varesamling)
            {
                this.UdskrivEnVare(vare);
                totalSalgsværdi += vare.Salgsværdi();
                totalIndkøbsværdi += vare.Indkøbsværdi();
            }

            Console.WriteLine("--------------------------------------------------");

            UdskrivTotalSalgsværdi(totalSalgsværdi);
            UdskrivTotalIndkøbsværdi(totalIndkøbsværdi);
        }

        // metode der udskriver en enkelt vare, der angives som input-parameter
        private void UdskrivEnVare(Vare vare)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Varenr: " + vare.Varenr);
            Console.WriteLine("Betegnelse: " + vare.Betegnelse);
            Console.WriteLine("Enhed: " + vare.Enhed);
            Console.WriteLine("Antal enheder på lager: " + vare.AntalPåLager);
            Console.WriteLine("Antal solgte enheder: " + vare.SolgtAntal);
            Console.WriteLine("Antal indkøbte enheder: " + vare.IndkøbtAntal);
            Console.WriteLine("Antal minimum enheder på lager : " +vare.MinimumsAntal);
            Console.WriteLine("Salgspris pr. enhed: " + vare.SalgsEnhedsPris.ToString("c2"));
            Console.WriteLine("Salgsværdi: " + vare.Salgsværdi().ToString("c2"));//NB: metodekald
            Console.WriteLine("Indkøbspris pr. enhed: " + vare.IndkøbEnhedsPris.ToString("c2"));
            Console.WriteLine("Indkøbsværdi: " + vare.Indkøbsværdi().ToString("c2"));
        }

        // metode der udskriver den totale salgsværdi over alle varer
        private void UdskrivTotalSalgsværdi(double totalSalgsværdi)
        {
            Console.WriteLine("Total salgsværdi: " + totalSalgsværdi.ToString("c2"));
        }

        // metode der udskriver den totale indkøbsværdi over alle varer
        private void UdskrivTotalIndkøbsværdi(double totalIndkøbsværdi)
        {
            Console.WriteLine("Total indkøbsværdi: " + totalIndkøbsværdi.ToString("c2"));
        }

        // metode der udskriver registrering af solgte varer
        private void UdskrivRegistreringAfSalg(int antal, Vare vare)
        {
            Console.WriteLine("Der er blevet registreret af der er blevet solgt {0} stk. af varen med varenr {1}", antal, vare.Varenr);
        }

        private void UdskrivRegistreringAfIndkøb(int antal, Vare vare)
        {
            Console.WriteLine("Der er blevet registreret af der er blevet indkøbt {0} stk. af varen med varenr {1}", antal, vare.Varenr);
        }
    }
}