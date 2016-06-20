using System;
using System.Collections.Generic;

namespace VarekartotekApplication
{
	// Program-igangs�tter for console applicationen
	static class Program {[STAThread]static void Main(string[] args){new VarekartotekConsoleApplication();}}

	// definition af "Hoved-programmet" (data og metoder der findes i hovedprogrammet)
	public class VarekartotekConsoleApplication
	{
		// Application objectets memory (datafelter)
		List<Vare>  varesamling;

		// opstarts metoden (constructor)
		public VarekartotekConsoleApplication()
		{
			this.varesamling = new List<Vare>();	 // opret tom varesamling
			this.OpretTestVarer();					 // fyld data i 
			this.UdskrivAlleVarer();				 // udskriv

			Console.ReadLine();						// Pause - vent p� return !!
		}

		// metode der opretter test varer
		public void OpretTestVarer ()
		{
			varesamling.Add( new Vare (1001, "A4 blok ternet med huller", "Blok", 10, 3.98f, 2.56f) );
			varesamling.Add( new Vare (1002, "A4 blok linieret med huller", "Blok", 20, 3.88f, 2.73f) );
			varesamling.Add( new Vare (1003, "Blyant Viking 400x2", "�ske", 110, 0.64f, 0.45f) );
            varesamling.Add(new Vare(1004, "Lenovo b�rbar", "Styk", 2, 4999f, 1500f));
            varesamling.Add(new Vare(1005, "Blyantspidser", "Styk", 57, 9.5f, 0.53f));
        }

		// metode der udskriver en oversigt over alle varer i samlingen
		public void UdskrivAlleVarer ()
		{
            double totalSalgsv�rdi = 0;
            double totalIndk�bsv�rdi = 0;

            Console.WriteLine("Vare oversigt");
			foreach (Vare vare in varesamling)
			{
				this.UdskrivEnVare(vare);
                totalSalgsv�rdi += vare.Salgsv�rdi();
                totalIndk�bsv�rdi += vare.Indk�bsv�rdi();
            }

            Console.WriteLine("--------------------------------------------------");

            UdskrivTotalSalgsv�rdi(totalSalgsv�rdi);
            UdskrivTotalIndk�bsv�rdi(totalIndk�bsv�rdi);
		}

		// metode der udskriver en enkelt vare, der angives som input-parameter
		public void UdskrivEnVare (Vare vare)
		{
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("Varenr: " + vare.Varenr);
			Console.WriteLine("Betegnelse: " + vare.Betegnelse);
            Console.WriteLine("Enhed: " + vare.Enhed);
			Console.WriteLine("Antal enheder p� lager: " + vare.AntalP�Lager);
            Console.WriteLine("Salgspris pr. enhed: " + vare.SalgsEnhedsPris.ToString("c2"));
			Console.WriteLine("Salgsv�rdi: " + vare.Salgsv�rdi().ToString("c2") );//NB: metodekald
            Console.WriteLine("Indk�bspris pr. enhed: " + vare.Indk�bEnhedsPris.ToString("c2"));
            Console.WriteLine("Indk�bsv�rdi: " + vare.Indk�bsv�rdi().ToString("c2"));
        }

        public void UdskrivTotalSalgsv�rdi(double totalSalgsv�rdi)
        {
            Console.WriteLine("Total salgsv�rdi: " + totalSalgsv�rdi.ToString("c2"));
        }

        public void UdskrivTotalIndk�bsv�rdi(double totalIndk�bsv�rdi)
        {
            Console.WriteLine("Total indk�bsv�rdi: " + totalIndk�bsv�rdi.ToString("c2"));
        }
    }

	// definition af Vare (data og metoder der findes for hver enkelt vare-object
	public class Vare
	{
		// vare-objektes memory (datafelter)
		public int		Varenr;
		public string	Betegnelse;
        public string   Enhed;
        public int		AntalP�Lager;
		public float	SalgsEnhedsPris;			// aktuel excl. moms
        public float    Indk�bEnhedsPris;

		// constructor til brug for skabelse af nyt vare-object
		public Vare (int varenr, string betegnelse, string enhed, int antalP�Lager, float salgsEnhedsPris, float indk�bsEnhedsPris)
		{
			this.Varenr = varenr;
			this.Betegnelse = betegnelse;
            this.Enhed = enhed;
			this.AntalP�Lager = antalP�Lager;
			this.SalgsEnhedsPris = salgsEnhedsPris;
            this.Indk�bEnhedsPris = indk�bsEnhedsPris;
		}

		// metode for beregning af salgsv�rdien for det samlede antal
		public double Salgsv�rdi ()
		{
			double salgsv�rdi = this.SalgsEnhedsPris * this.AntalP�Lager;
			return salgsv�rdi;
		}

        // metode for beregning af indk�bsv�rdien for det samlede antal
        public double Indk�bsv�rdi()
        {
            double indk�bsv�rdi = this.Indk�bEnhedsPris * this.AntalP�Lager;
            return indk�bsv�rdi;
        }
    }
}
