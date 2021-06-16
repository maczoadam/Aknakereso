using System;

namespace Aknakereső
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a pálya méretét: ");
            int meret = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg az aknák számát: ");
            int aknakszama = int.Parse(Console.ReadLine());
            Aknamezo mezo1 = new Aknamezo(meret, aknakszama);
            mezo1.Mutat();
            int menu = 0;
            int x, y;
            string koordinata;
            /*while (menu != 4) 
            {
                Console.WriteLine("Adja meg a koordinátákat(x,y): ");
                koordinata = Console.ReadLine();
                x = int.Parse(koordinata.Split(',')[0]);
                y = int.Parse(koordinata.Split(',')[1]);


            }*/


            Console.ReadKey();
        }
    }

    class Aknamezo
    {
        int[,] szamok; //Számok helyzete
        int aknakszama;
        Random rnd = new Random();

        public Aknamezo(int meret, int aknakszama)
        {
            this.szamok = new int[meret, meret];
            this.aknakszama = aknakszama;
            Feltoltes();
            SzamokFeltoltese();
        }

        void Feltoltes()
        {           
            int x, y, count;
            count = 0;
            while (count < aknakszama) //Aknák random elheyezése
            {
                x = rnd.Next(0, szamok.GetLength(0));
                y = rnd.Next(0, szamok.GetLength(1));
                if (szamok[x, y] != -1)
                {
                    szamok[x, y] = -1;
                    count++;
                }
            }
        }
        void SzamokFeltoltese() //Mezö körüli aknák számítása
        {
            for (int i = 0; i < szamok.GetLength(0); i++)
            {
                for (int j = 0; j < szamok.GetLength(1); j++)
                {
                    szamok[i, j] = Aknakalkulator(i, j);
                }
            }
        }
        int Aknakalkulator(int x, int y)
        {
            int db = 0;
            if (szamok[x, y] != -1)
            {
                if (Hataronbelul(x - 1, y - 1)) { if (szamok[x - 1, y - 1] == -1) db++; }
                if (Hataronbelul(x - 1, y)) { if (szamok[x - 1, y] == -1) db++; }
                if (Hataronbelul(x - 1, y + 1)) { if (szamok[x - 1, y + 1] == -1) db++; }
                if (Hataronbelul(x, y - 1)) { if (szamok[x, y - 1] == -1) db++; }
                if (Hataronbelul(x, y + 1)) { if (szamok[x, y + 1] == -1) db++; }
                if (Hataronbelul(x + 1, y - 1)) { if (szamok[x + 1, y - 1] == -1) db++; }
                if (Hataronbelul(x + 1, y)) { if (szamok[x + 1, y] == -1) db++; }
                if (Hataronbelul(x + 1, y + 1)) { if (szamok[x + 1, y + 1] == -1) db++; }

                return db;
            }
            return -1;
        }
        bool Hataronbelul(int x, int y)
        {
            if (x < 0 || y < 0 || x >= szamok.GetLength(0) || y >= szamok.GetLength(1))
            {
                return false;
            }
            else { return true; }
        }

        public void Mutat() 
        {
            Console.Clear();
            /*for (int i = 0; i < szamok.GetLength(0); i++)
            {
                for (int j = 0; j < szamok.GetLength(1); j++)
                {
                    Console.Write("# ");
                }
                Console.WriteLine();
            }*/

            Console.WriteLine();
            for (int i = 0; i < szamok.GetLength(0); i++)
            {
                for (int j = 0; j < szamok.GetLength(1); j++)
                {
                    Console.Write(szamok[i,j]+ "  ");
                }
                Console.WriteLine();
            }

        }
    }
}
