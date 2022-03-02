using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace jaror
{
    class Program
    {
        class Adat
        {
            public int hour;
            public int min;
            public int sec;
            public DateTime dt;
            public string betuk;
            public int szamok;
        }
        static void Main(string[] args)
        {
            List<Adat> lista = new List<Adat>();
            string[] sorok = File.ReadAllLines("jarmu.txt");
            foreach (string sor in sorok)
            {
                Adat a = new Adat();
                string[] s = sor.Split(' ');
                a.hour = int.Parse(s[0]);
                a.min = int.Parse(s[1]);
                a.sec = int.Parse(s[2]);
                a.dt = new DateTime(1, 1, 1, int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
                string[] sz = s[3].Split('-');
                a.betuk = sz[0];
                a.szamok = int.Parse(sz[1]);
                lista.Add(a);
            }

            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Az ellenőrzést végzők legalább {lista.Last().dt.Hour - lista.First().dt.Hour + 1} órát dolgoztak.");
            Console.WriteLine("3. feladat:");
            for (int i = lista.First().dt.Hour; i < lista.Last().dt.Hour + 1; i++)
            {
                Console.WriteLine($"{i} óra: {lista.First(x => x.dt.Hour == i).betuk}-{lista.First(x => x.dt.Hour == i).szamok}");
            }
        }
    }
}
