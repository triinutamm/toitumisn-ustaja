using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toitumisnõustaja
{
    class Program
    {
        static void Main(string[] args)
        {
            // listi nimi kasutajad, milles nurkade vahel oleva klassi sisu
            List<kasutaja> kasutajad = new List<kasutaja>();
            Console.WriteLine("Teretulemast!\nValige soovoitud toiming:\nLOGI SISSE\nLOO KASUTAJA\n");
            string toiming = Console.ReadLine();
            if (toiming == "LOO KASUTAJA")
            {
                lookasutaja(kasutajad);
            }
            if (toiming == "LOGI SISSE" )
            {
                int user_id = Login(kasutajad);


            }


        }

        public static int Login(List<kasutaja> kasutajad)
        {
            Console.WriteLine("Sisestage kasutajanimi");
            string kasutajanimi = Console.ReadLine();
            Console.WriteLine("Sisestage parool");
            string parool = Console.ReadLine();

            string[] s;
            string kasutajanimi2, parool2;
            int user_id = 0;
            string[] lines = File.ReadAllLines("../../andmed.txt");
            foreach (var item in lines)
            {
                s = item.Split(':');
                kasutajanimi2 = s[0];
                parool2 = s[1];
                
                if (kasutajanimi2 == kasutajanimi)
                {
                    if (parool2 == parool)
                    {
                        Console.WriteLine("Sisselogimine õnnestus!");
                        return user_id;
                    }
                    else
                    {
                        Console.WriteLine("Vale parool!");

                    }
                }
                user_id++;


            }
            return user_id;


            //Console.WriteLine(kasutajanimi2);
            //if (kasutajanimi2 == kasutajanimi)
            //{
            //    if (kasutajad[user_id].parool == parool)
            //    {

            //        Console.WriteLine("Sisselogimine õnnestus!");
            //        return user_id;
            //    }
            //    else
            //    {
            //        Console.WriteLine("VALE PAROOL");
            //        return -1;
            //    }

            //}


            //for (int user_id = 0; user_id < kasutajad.Count; user_id ++)
            //{
            //    Console.WriteLine("peale fori");
            //    if (kasutajad[user_id].kasutajanimi == kasutajanimi)
            //    {
            //        if (kasutajad[user_id].parool == parool)
            //        {

            //            Console.WriteLine("Sisselogimine õnnestus!");
            //            return user_id;
            //        }
            //        else
            //        {
            //            Console.WriteLine("VALE PAROOL");
            //            return -1;
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("Sellist kasutajat ei leitud");
            //        return -1;
            //    }

            //}
            //    return 1;


        }
        public static void lookasutaja(List<kasutaja> kasutajad)
        {
            //KASUTAJANIMI
            Console.WriteLine("Sisestage kasutajanimi");
            string kasutajanimi = Console.ReadLine();

            //PAROOL
            Console.WriteLine("Sisestage parool");
            string parool = Console.ReadLine();

            //KAAL
            Console.WriteLine("Sisestage oma kaal");
            string stringkaal = Console.ReadLine();
            int kaal = Int32.Parse(stringkaal);

            //PIKKUS
            Console.WriteLine("Sisestage oma pikkus");
            string stringpikkus = Console.ReadLine();
            int pikkus = Int32.Parse(stringkaal);

            // VANUS
            Console.WriteLine("Sisestage enda sünniaasta - YYYY");
            string aasta = Console.ReadLine();
            Console.WriteLine("Sisestage enda sünnikuu - MM");
            string kuu = Console.ReadLine();
            string currentMonth = DateTime.Now.Month.ToString();
            string currentYear = DateTime.Now.Year.ToString();
            int vanus = (Int32.Parse(currentYear + currentMonth) - Int32.Parse(aasta + kuu)) / 100;


            kasutaja uus_kasutaja = new kasutaja();
            uus_kasutaja.kasutajanimi = kasutajanimi;
            uus_kasutaja.parool = parool;
            uus_kasutaja.vanus = vanus;
            uus_kasutaja.pikkus = pikkus;
            uus_kasutaja.kaal = kaal;

            kasutajad.Add(uus_kasutaja);
            File.AppendAllText("../../andmed.txt", kasutajanimi + ":" + parool + ":" + kaal + ":" + pikkus + ":" + vanus +  ";\n");
            string[] s;
            string kasutajanimi2, parool2;
            string[] lines = File.ReadAllLines("../../andmed.txt");
            foreach(var item in lines)
            {
                s = item.Split(':');
                kasutajanimi2 = s[0];
                parool2 = s[1];

                Console.WriteLine("Teretulemast, " + kasutajanimi);
            }

           
        }
    }
}
