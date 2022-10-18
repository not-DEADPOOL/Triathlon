using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es { 
    internal class athlete
    {
        struct atleta
        {
            public string nome;
            public int eta;
            public double tempoNuoto;
            public double tempoCorsa;
            public double tempoCiclista;
            public double tempoTotale;
        }
        static void Main(string[] args)
        {
            List<atleta> atleti = new List<atleta>();
            string[] input = File.ReadAllLines("balls.txt");
            for (int i = 0; i < input.Length; i++)
            {
                string[] elem = input[i].Split('|');
                attrib(elem, atleti);
            }
            Console.WriteLine("Partecipanti:");
            Console.WriteLine("=========================================================================");
            for (int i = 0; i < atleti.Count; i++)
            {
                Console.WriteLine($"{atleti[i].nome}");
            }
            Console.WriteLine("=========================================================================");
            Massimo_min(atleti);
            Console.WriteLine("=========================================================================");
            Classifiche_nuoto(atleti);
            Console.WriteLine("=========================================================================");
            Classifiche_corsa(atleti);
            Console.WriteLine("=========================================================================");
            Classifiche_cicli(atleti);
            Console.WriteLine("=========================================================================");
            Classifiche_tot(atleti);
            Console.WriteLine("=========================================================================");
            Console.ReadKey();
        }
        static void attrib(string[] elem, List<atleta> atleti)
        {
            atleta soggetto;
            soggetto.nome = elem[0];
            soggetto.eta = Convert.ToInt32(elem[1]);
            soggetto.tempoNuoto = Convert.ToDouble(elem[2]);
            soggetto.tempoCorsa = Convert.ToDouble(elem[3]);
            soggetto.tempoCiclista = Convert.ToDouble(elem[4]);
            soggetto.tempoTotale = soggetto.tempoCiclista + soggetto.tempoCorsa + soggetto.tempoNuoto;
            atleti.Add(soggetto);
        }
        static void Classifiche_nuoto(List<atleta> atleti)
        {
            double[] podio = new double[atleti.Count];
            atleta tmp;

            for (int i = 0; i < podio.Length; i++)
            {
                for (int j = 0; j < podio.Length; j++)
                {
                    if (atleti[i].tempoNuoto < atleti[j].tempoNuoto)
                    {
                        tmp = atleti[i];
                        atleti[i] = atleti[j];
                        atleti[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Classifica nuoto:");
            for (int i = 0; i < atleti.Count; i++)
            {
                Console.WriteLine($"{i + 1}° posto ->{atleti[i].nome}");
            }
            
        }
        static void Classifiche_cicli(List<atleta> atleti)
        {
            double[] podio = new double[atleti.Count];
            atleta tmp;

            for (int i = 0; i < podio.Length; i++)
            {
                for (int j = 0; j < podio.Length; j++)
                {
                    if (atleti[i].tempoCiclista < atleti[j].tempoCiclista)
                    {
                        tmp = atleti[i];
                        atleti[i] = atleti[j];
                        atleti[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Classifica ciclismo:");
            for (int i = 0; i < atleti.Count; i++)
            {
                Console.WriteLine($"{i + 1}° posto ->{atleti[i].nome}");
            }
        }
        static void Classifiche_corsa(List<atleta> atleti)
        {
            double[] podio = new double[atleti.Count];
            atleta tmp;

            for (int i = 0; i < podio.Length; i++)
            {
                for (int j = 0; j < podio.Length; j++)
                {
                    if (atleti[i].tempoCorsa < atleti[j].tempoCorsa)
                    {
                        tmp = atleti[i];
                        atleti[i] = atleti[j];
                        atleti[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Classifica corsa:");
            for (int i = 0; i < atleti.Count; i++)
            {
                Console.WriteLine($"{i + 1}° posto ->{atleti[i].nome}");
            }
        }
        static void Classifiche_tot(List<atleta> atleti)
        {
            double[] podio = new double[atleti.Count];
            atleta tmp;

            for (int i = 0; i < podio.Length; i++)
            {
                for (int j = 0; j < podio.Length; j++)
                {
                    if (atleti[i].tempoTotale < atleti[j].tempoTotale)
                    {
                        tmp = atleti[i];
                        atleti[i] = atleti[j];
                        atleti[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Classifica dei tempi totali:");
            for (int i = 0; i < atleti.Count; i++)
            {
                Console.WriteLine($"{i+1}° posto ->{atleti[i].nome}");
            }
        }
        static void Massimo_min(List<atleta> atleti)
        {
            int massimo = int.MinValue;
            int minimo = int.MaxValue;
            string nome1 = null, nome2 = null;
            for (int i = 0; i < atleti.Count; i++)
            {
                if (massimo < atleti[i].eta)
                {
                    massimo = atleti[i].eta;
                    nome1 = atleti[i].nome;
                }
                if (minimo > atleti[i].eta)
                {
                    minimo = atleti[i].eta;
                    nome2 = atleti[i].nome;
                }
            }
            Console.WriteLine($"{nome1} è il più anziano con {massimo} anni.");
            Console.WriteLine($"{nome2} è il più giovane con {minimo} anni.");
        }
        

    }
}
