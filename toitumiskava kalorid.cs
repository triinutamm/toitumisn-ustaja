using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valiga oma sugu\nmees\nnaine");
            string sugu = Console.ReadLine();
            kaloriarvutaja(sugu);
            eelistused();
        }
        public static void kaloriarvutaja(string sugu)
        {
            Console.WriteLine("Sisestage oma kaal:");
            string kaal = Console.ReadLine();
            int intkaal = Int32.Parse(kaal);


            Console.WriteLine("Sisestage oma pikkus:");
            string pikkus = Console.ReadLine();
            int intpikkus = Int32.Parse(pikkus);

            Console.WriteLine("Sisestage oma vanus");
            string vanus = Console.ReadLine();
            int intvanus = Int32.Parse(vanus);

            Console.WriteLine("Valige oma aste\naste 1 - vähe/mitte üldse trenni\naste 2 - kerge trenn (1-3x nädalas)\naste 3 - mõõdukas trenn (3-5x nädalas)\naste 4 - intensiivne trenn 6-7x nädalas\naste 5 - väga intensiivne trenn(2x päevas, väga rasked treeningud)");
            string aste = Console.ReadLine();

            double intaste = 0;
            if (aste == "aste 1")
            {

                intaste = 1.2;
            }
            if (aste == "aste 2")
            {
                intaste = 1.375;
            }
            if (aste == "aste 3")
            {
                intaste = 1.55;
            }
            if (aste == "aste 4")
            {
                intaste = 1.725;
            }
            if (aste == "aste 5")
            {
                intaste = 1.9;
            }
            else Console.WriteLine();

            if (sugu == "naine")
            {
                double naisevalem = (655.1 + (9.563 * intkaal) + (1.850 * intpikkus) - (4.676 * intvanus)) * intaste;
                Console.WriteLine("Sinu päevane kalorivajadus on: " + naisevalem);
            }
            else
            {
                double mehevalem = (66.5 + (13.75 * intkaal) + (5.003 * intpikkus) - (6.775 * intvanus)) * intaste;
                Console.WriteLine("Sinu päevane kalorivajadus on: " + mehevalem);

            }

        }

        public static void eelistused()
        {
            Console.WriteLine("eelistus\nei ole eelistusi\ntaimetoitlane\nkalatoiduline\nmuu");
            string eelistus = Console.ReadLine();

            if (eelistus == "ei ole eelistusi")
            {
                try
                {
                    System.Diagnostics.Process.Start("https://www.fitlap.ee/retseptid/");
                }
                catch { }

            }
        }


        
    }
}

