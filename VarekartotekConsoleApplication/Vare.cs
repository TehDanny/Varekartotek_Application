using System;
using System.Collections.Generic;
using System.Text;

namespace VarekartotekApplication
{
    // definition af Vare (data og metoder der findes for hver enkelt vare-object
    class Vare
    {
        // vare-objektes memory (datafelter)
        private int varenr;
        public int Varenr
        {
            get { return varenr; }
        }

        private string betegnelse;
        public string Betegnelse
        {
            get { return betegnelse; }
        }

        private string enhed;
        public string Enhed
        {
            get { return enhed; }
        }

        private int antalPåLager;
        public int AntalPåLager
        {
            get { return antalPåLager; }
            set { antalPåLager = value; }
        }

        private int solgtAntal;
        public int SolgtAntal
        {
            get { return solgtAntal; }
            set { solgtAntal = value; }
        }

        private int indkøbtAntal;
        public int IndkøbtAntal
        {
            get { return indkøbtAntal; }
            set { indkøbtAntal = value; }
        }

        private int minimumsAntal;
        public int MinimumsAntal
        {
            get { return minimumsAntal; }
        }

        private float salgsEnhedsPris;  // aktuel excl. moms
        public float SalgsEnhedsPris
        {
            get { return salgsEnhedsPris; }
        }

        private float indkøbEnhedsPris;
        public float IndkøbEnhedsPris
        {
            get { return indkøbEnhedsPris; }
        }

        // constructor til brug for skabelse af nyt vare-object
        public Vare(int varenr, string betegnelse, string enhed, int antalPåLager, int solgtAntal, int indkøbtAntal, int minimumsAntal, float salgsEnhedsPris, float indkøbsEnhedsPris)
        {
            this.varenr = varenr;
            this.betegnelse = betegnelse;
            this.enhed = enhed;
            this.antalPåLager = antalPåLager;
            this.solgtAntal = solgtAntal;
            this.indkøbtAntal = indkøbtAntal;
            this.minimumsAntal = minimumsAntal;
            this.salgsEnhedsPris = salgsEnhedsPris;
            this.indkøbEnhedsPris = indkøbsEnhedsPris;
        }

        // metode for beregning af salgsværdien for det samlede antal
        public double Salgsværdi()
        {
            double salgsværdi = this.SalgsEnhedsPris * this.AntalPåLager;
            return salgsværdi;
        }

        // metode for beregning af indkøbsværdien for det samlede antal
        public double Indkøbsværdi()
        {
            double indkøbsværdi = this.IndkøbEnhedsPris * this.AntalPåLager;
            return indkøbsværdi;
        }

        internal static Vare FindEnVareMedVarenr(int menuValg, List<Vare> varesamling)
        {
            Vare fundetVare = null;
            foreach (Vare vare in varesamling)
            {
                if (vare.Varenr == menuValg)
                    fundetVare = vare;
            }
            return fundetVare;
        }

        // metode for beregning af antal varer efter et salg
        public void RegistrerVarerSolgt(int antal)
        {
            this.AntalPåLager -= antal;
            this.SolgtAntal += antal;
        }

        public void RegistrerVarerIndkøbt(int antal)
        {
            this.AntalPåLager += antal;
            this.IndkøbtAntal += antal;
        }
    }
}
