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

            //SISSELOGIMINE
            while(true)
            {
                Console.WriteLine("Tere!\nValige soovoitud toiming:\nLOGI SISSE\nLOO KASUTAJA\n");
                string toiming = Console.ReadLine();
                if (toiming == "LOO KASUTAJA")
                {
                    lookasutaja(kasutajad);
                    int user_id = Login(kasutajad);
                    kaloriarvutaja(user_id);
                    while (true)
                    {
                        Console.WriteLine("Milliseks toidukorraks ideid soovid?\n HOMMIKUSÖÖK\nLÕUNASÖÖK\nÕHTUSÖÖK\nVAHEPALA");
                        string toidukord = Console.ReadLine();
                        if (toidukord == "ÕHTUSÖÖK")
                        {
                            menüü(user_id, toidukord);
                        }
                        else
                        {
                            Console.WriteLine("Midagi läks valesti. Proovi uuesti!");
                        }
                    }
                }
                else if (toiming == "LOGI SISSE")
                {
                    int user_id = Login(kasutajad);
                    kaloriarvutaja(user_id);
                    while (true)
                    {
                        Console.WriteLine("Milliseks toidukorraks ideid soovid?\n HOMMIKUSÖÖK\nLÕUNASÖÖK\nÕHTUSÖÖK\nVAHEPALA");
                        string toidukord = Console.ReadLine();
                        if (toidukord == "ÕHTUSÖÖK")
                        {
                            menüü(user_id, toidukord);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sisestasid midagi valesti. Proovi uuesti!");
                   
                }

            }
        }
            

        public static int Login(List<kasutaja> kasutajad)
        {
            while (true)
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
                            Console.WriteLine("Tere, " + kasutajanimi + " ! Sisselogimine õnnestus!");
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
            }

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
            int pikkus = Int32.Parse(stringpikkus);

            // VANUS
            Console.WriteLine("Sisestage enda sünniaasta - YYYY");
            string aasta = Console.ReadLine();
            Console.WriteLine("Sisestage enda sünnikuu - MM");
            string kuu = Console.ReadLine();
            string currentMonth = DateTime.Now.Month.ToString();
            string currentYear = DateTime.Now.Year.ToString();
            int vanus = (Int32.Parse(currentYear + currentMonth) - Int32.Parse(aasta + kuu)) / 100;

            //Trenni aste
            Console.WriteLine("Valige oma aste\naste 1 - vähe/mitte üldse trenni\naste 2 - kerge trenn (1-3x nädalas)\naste 3 - mõõdukas trenn (3-5x nädalas)\naste 4 - intensiivne trenn 6-7x nädalas\naste 5 - väga intensiivne trenn(2x päevas, väga rasked treeningud)");
            string aste = Console.ReadLine();

            //SUGU
            Console.WriteLine("Sisestage sugu - M/N");
            string sugu = Console.ReadLine();

            //TOITUMISEELISTUSED
            Console.WriteLine("Valige, milliseid retsepte teile kuvame - omnivoor/vegan");
            string eelistused = Console.ReadLine();


            kasutaja uus_kasutaja = new kasutaja();
            uus_kasutaja.kasutajanimi = kasutajanimi;
            uus_kasutaja.parool = parool;
            uus_kasutaja.vanus = vanus;
            uus_kasutaja.pikkus = pikkus;
            uus_kasutaja.kaal = kaal;
            uus_kasutaja.aste = aste;
            uus_kasutaja.sugu = sugu;
            uus_kasutaja.eelistused = eelistused;

            kasutajad.Add(uus_kasutaja);
            File.AppendAllText("../../andmed.txt", kasutajanimi + ":" + parool + ":" + kaal + ":" + pikkus + ":" + vanus + ":" + aste + ":" + sugu + ":" + eelistused + ":"  + Environment.NewLine);
            Console.WriteLine("Teretulemast, " + kasutajanimi);


        }
        public static void kaloriarvutaja(int user_id)
        {
            double intaste = 0;
            string[] s;
            string aste = "";
            string kaal = "";
            string pikkus = "";
            string vanus = "";
            string sugu = "";
            string[] lines = File.ReadAllLines("../../andmed.txt");
            int counter = 0;

            foreach (var item in lines)
            {
                if (user_id == counter)
                {
                    s = item.Split(':');
                    kaal = s[2];
                    pikkus = s[3];
                    vanus = s[4];
                    aste = s[5];
                    sugu = s[6];
                }
                else
                {
                    counter++;
                }

            }
            int intkaal = Int32.Parse(kaal);
            int intpikkus = Int32.Parse(pikkus);
            int intvanus = Int32.Parse(vanus);

            if (aste == "aste 1")
            {
                intaste = 1.2;
            }
            else if (aste == "aste 2")
            {
                intaste = 1.375;
            }
            else if (aste == "aste 3")
            {
                intaste = 1.55;
            }
            else if (aste == "aste 4")
            {
                intaste = 1.725;
            }
            else if (aste == "aste 5")
            {
                intaste = 1.9;
            }
            else
            {
                Console.WriteLine("yop, siin elses midagi läks nihu");
            }


            if (sugu == "N")
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
        public static void menüü(int user_id, string toidukord )
        {
            string eelistused = "";
            int counter = 0;
            string[] s;
            ConsoleKeyInfo cki;
            string[] lines = File.ReadAllLines("../../andmed.txt");
            foreach (var item in lines)
            {
                if (user_id == counter)
                {
                    s = item.Split(':');
                    eelistused = s[7];
                }
                else
                {
                    counter++;
                }

            }
            Console.WriteLine(eelistused);
            while (eelistused == "omnivoor")
            {
                if (toidukord == "ÕHTUSÖÖK")
                {
                    Console.WriteLine("ÕHTUSÖÖGI RETSEPTI KUVAMISEKS VAJUTAGE ENTER\nTAGASI MENÜÜSSE LIIKUMISEKS VAJUTAGE ESC");
                    cki = Console.ReadKey();
                    for (int i = 0; i < 5; i++)
                    {
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            string text = File.ReadAllText("../../" + toidukord + i + ".txt", Encoding.Default);
                            Console.WriteLine(text);
                            Console.WriteLine("JÄRGMISE RETSEPTI KUVAMISEKS VAJUTAGE ENTER\nTAGASI MENÜÜSSE SAAMISEKS VAJUTAGE ESC");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }


                    }
                    
                }
                else
                {
                    break;
                }
                break;
            }
        }
        //        public static void eelistused()
        //        {
        //            Console.WriteLine("eelistus\nei ole eelistusi\ntaimetoitlane\nkalatoiduline\nmuu");
        //            string eelistus = Console.ReadLine();

        //            if (eelistus == "ei ole eelistusi")
        //            {
        //                try
        //                {

        //                }
        //                catch { }

        //            }
        //        }
    }
}
