using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();

        static void MasodikFeladat()
        {
            StreamReader File = new StreamReader("eredmenyek.csv");
            File.ReadLine();
            while (!File.EndOfStream)
            {
                string[] sor = File.ReadLine().Split(';');
                meccsek.Add(new Meccs(sor[0], sor[1], int.Parse(sor[2]), int.Parse(sor[3]), sor[4], sor[5]));
            }
            File.Close();
        }
        static void HarmadikFeladat()
        {
            int otthon = 0;
            int idegenbe = 0;
            foreach (var cs in meccsek)
            {
                if (cs.Hazai == "Real Madrid")
                {
                    otthon++;
                }
                else if (cs.Idegen == "Real Madrid")
                {
                    idegenbe++;
                }
            }

            // Select megoldás:

            var hazai = from m in meccsek
                        where m.Hazai == "Real Madrid"
                        select new { Hazai = m.Hazai };

            int hazaiDB = hazai.ToList().Count;

            var idegen = from m in meccsek
                        where m.Idegen == "Real Madrid"
                        select new { Idegen = m.Idegen };

            int idegenDB = hazai.ToList().Count;

            //

            Console.WriteLine($"3. Feladat: Real Madrid: Hazai: {otthon} Idegen: {idegenbe}");

            Console.WriteLine($"3. Feladat: Select megoldás: Hazai: {hazaiDB} Idegen: {idegenDB}");
        }
        static void NegyedikFeladat()
        {
            bool dontetlen = false;
            foreach (var m in meccsek)
            {
                if (m.HPont == m.IPont)
                {
                    dontetlen = true;
                }
                else
                {
                    dontetlen = false;
                }
            }
            if (dontetlen)
            {
                Console.WriteLine("4. Feladat: Volt döntetlen? igen");
            }
            else Console.WriteLine("4. Feladat: Volt döntetlen? nem");
        }
        static void OtodikFeladat()
        {
            var bar = from b in meccsek
                      where b.Hazai.Contains("Barcelona")
                      select new { Hazai = b.Hazai };
            var barnev = bar.ToArray()[0].Hazai;
            Console.WriteLine($"5. Feladat: {barnev}");
            
        }
        static void HatodikFeladat()
        {
            Console.WriteLine("6.Feladat:");
            var datum = from m in meccsek
                        where m.Ido == "2004-11-21"
                        select new
                        {
                            Hazai = m.Hazai,
                            Idegen = m.Idegen,
                            HP = m.HPont,
                            IP = m.IPont
                        };

            foreach (var d in datum)
            {
                Console.WriteLine($"\t{d.Hazai} {d.Idegen} ({d.HP}:{d.IP})");
            }
        }
        static void HetedikFeladat()
        {
            Console.WriteLine("7. Feladat:");
            var stadionok = from m in meccsek
                            orderby m.Hely
                            group m by m.Hely into stadion
                            select stadion;

            foreach (var stadion in stadionok)
            {
                if (stadion.Count() > 20)
                {
                    Console.WriteLine($"\t{stadion.Key}: {stadion.Count()}");
                }
            }
        }
        static void NyolcadikFeladat()
        {
            StreamWriter iras = new StreamWriter("Meccsek.txt");
            foreach (var m in meccsek)
            {
                iras.WriteLine(m.Atalakit());
            }
        }

        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();
            NyolcadikFeladat();
            Console.ReadLine();
        }
    }
}
