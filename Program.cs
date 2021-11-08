using System;
using System.Text;
using System.Collections.Generic; //żeby używac listy

namespace CS_kasa_sklepowa
{
    class Program
    {

        public static void Przerywnik() //wyswietla przerywnik
        {
            Console.WriteLine("----------------------------");
        }

        public struct produkt
        {
            public String nazwa;
            public bool kgIlosc;
            public double cena;
            public int iloscSztuk;
            public String jednostka;
            public double cenaRazyIlosc;

            public void WyswietlDanePrzyDodawaniuProdukt() //wyswietla dane nt produktu przy jego dodawaniu
            {
                Console.Write("Ile prduktów o nazwie: '" + nazwa + "' dodac, w cenie " + String.Format("{0:0.00}", cena) + " zł");
                if (kgIlosc) Console.Write(" za 1 kg");
                else Console.Write(" za sztuke");
                Console.Write("\n");
                iloscSztuk = int.Parse(Console.ReadLine());
                cenaRazyIlosc = cena * iloscSztuk;
            }
            public void IleDodanoProduktowProdukt() //informuje ile dodało produktów
            {
                Console.WriteLine("Dodano " + iloscSztuk + " produktu: " + nazwa + " za kwotę " + String.Format("{0:0.00}", cenaRazyIlosc));
            }

            public void WyswietlProduktDoParagonu(int index) // wyswietla sformatowane dane o produkcie do paragonu
            {
                index++;
                Console.Write(index + ". " + nazwa + " x " + String.Format("{0:0.00}", ));
                if (kgIlosc) Console.Write(" za 1 kg ");
                else Console.Write(" za sztuke ");
                Console.Write(" = " + String.Format("{0:0.00}", cenaRazyIlosc) + " zł\n");
            }
        }


        static void Main(string[] args)
        {
            //definiowanie produktów według listy
            produkt[] produkty = new produkt[5];
            produkty[0].nazwa = "jablka";
            produkty[0].cena = 3.40;
            produkty[0].kgIlosc = true;
            produkty[1].nazwa = "jajka";
            produkty[1].cena = 5.00;
            produkty[1].kgIlosc = false;
            produkty[2].nazwa = "karton mleka";
            produkty[2].cena = 2.90;
            produkty[2].kgIlosc = false;
            produkty[3].nazwa = "bulka kaizerka";
            produkty[3].cena = 0.80;
            produkty[3].kgIlosc = false;
            produkty[4].nazwa = "foliowa reklamówka";
            produkty[4].cena = 0.30;
            produkty[4].kgIlosc = false;

            //------------DIALOG Z GRACZEM-------------------
            int wybor = 0; //podstawowy int do podejmowania decyzji
            List<int> listaZakupow = new List<int>();  // tabela z zapisanymi produktami oraz ich kolejnoscia
            for (int i = 0; wybor != 10; i++)
            {
                Console.Write("Siema ziomeczku, co dodac? (10 oznacza wydruk paragonu) \n   1. Jabłka \n   2. Jajka (12 szt. w opakowaniu) \n   3. Karton mleka \n   4. Bułkę kaizerka \n   5. Foliową reklamówkę \n");
                wybor = int.Parse(Console.ReadLine());
                if (wybor != 10) // dodawanie produktów do listy zakupów
                {
                    wybor--;
                    Console.Clear();
                    produkty[wybor].WyswietlDanePrzyDodawaniuProdukt();
                    produkty[wybor].IleDodanoProduktowProdukt();
                    listaZakupow.Add(wybor); //dodanie towaru do listy zakupow
                    Przerywnik();
                }

            }//koniec dodawania produktów

            //------------WYSWIETLANIE PARAGONU-------------------
            Console.WriteLine("     -----           PARAGON NR. 14470           -----");
            Console.WriteLine("SKLEPU HANDOLWEGO '5PRODUKTÓW I WSZYSTKO MASZ' SP. z O. O.\n");
            int j = 0;
            foreach(int a in listaZakupow)
            {
                produkty[a].WyswietlProduktDoParagonu(j);
                j++; 
            }
        }
    }
}
