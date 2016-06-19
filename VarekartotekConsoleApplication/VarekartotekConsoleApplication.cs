using System;
using System.Collections.Generic;

namespace VarekartotekApplication
{
	// Program-igangsætter for console applicationen
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

			Console.ReadLine();						// Pause - vent på return !!
		}

		// metode der opretter test varer
		public void OpretTestVarer ()
		{
			varesamling.Add( new Vare (1001, "A4 blok ternet med huller", 10, 3.98f) );
			varesamling.Add( new Vare (1002, "A4 blok linieret med huller", 20, 3.88f) );
			varesamling.Add( new Vare (1003, "Blyant Viking 400x2", 110, 0.64f) );
		}

		// metode der udskriver en oversigt over alle varer i samlingen
		public void UdskrivAlleVarer ()
		{
			Console.WriteLine("Vare oversigt");
			foreach (Vare vare in varesamling)
			{
				this.UdskrivEnVare(vare);
			}
		}

		// metode der udskriver en enkelt vare, der angives som input-parameter
		public void UdskrivEnVare (Vare vare)
		{
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("Varenr: " + vare.Varenr);
			Console.WriteLine("Betegnelse: " + vare.Betegnelse);
			Console.WriteLine("Antal enheder på lager: " + vare.AntalPåLager);
			Console.WriteLine("Salgsværdi: " + vare.Salgsværdi() );//NB: metodekald
		}
	}

	// definition af Vare (data og metoder der findes for hver enkelt vare-object
	public class Vare
	{
		// vare-objektes memory (datafelter)
		public int		Varenr;
		public string	Betegnelse;
		public int		AntalPåLager;
		public float	SalgsEnhedsPris;			// aktuel excl. moms

		// constructor til brug for skabelse af nyt vare-object
		public Vare (int varenr, string betegnelse,	int antalPåLager, float salgsEnhedsPris)
		{
			this.Varenr = varenr;
			this.Betegnelse = betegnelse;
			this.AntalPåLager = antalPåLager;
			this.SalgsEnhedsPris = salgsEnhedsPris;
		}

		// metode for beregning af den salgsværdien det samlede antal
		public double Salgsværdi ()
		{
			double salgsværdi = this.AntalPåLager * 3;
			return salgsværdi;
		}
	}
}
