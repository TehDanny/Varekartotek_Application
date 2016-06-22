﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VarekartotekApplication
{
    // definition af Vare (data og metoder der findes for hver enkelt vare-object
    class Vare
    {
        // vare-objektes memory (datafelter)
        public int Varenr;
        public string Betegnelse;
        public string Enhed;
        public int AntalPåLager;
        public int SolgtAntal;
        public int IndkøbtAntal;
        public int MinimumsAntal;
        public float SalgsEnhedsPris;			// aktuel excl. moms
        public float IndkøbEnhedsPris;

        // constructor til brug for skabelse af nyt vare-object
        public Vare(int varenr, string betegnelse, string enhed, int antalPåLager, int solgtAntal, int indkøbtAntal, int minimumsAntal, float salgsEnhedsPris, float indkøbsEnhedsPris)
        {
            this.Varenr = varenr;
            this.Betegnelse = betegnelse;
            this.Enhed = enhed;
            this.AntalPåLager = antalPåLager;
            this.SolgtAntal = solgtAntal;
            this.IndkøbtAntal = indkøbtAntal;
            this.MinimumsAntal = minimumsAntal;
            this.SalgsEnhedsPris = salgsEnhedsPris;
            this.IndkøbEnhedsPris = indkøbsEnhedsPris;
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
