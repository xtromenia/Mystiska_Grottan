using System;
using System.Collections.Generic;
using System.Text;

namespace Mystiska_Grottan
{
    public class Level
    {
        private int höjd, bredd;
        private string levelNamn;
        private Kvadrat[,] kvadrater;
        static int currentYPos;
        static int currentXPos;

        static int fightMenyVal = 0;
        static string[,] fightMeny = { { "Attack", "1" }, { "Items", "0" }, { "Pass", "0" }, { "Flee", "0" } };
        public Level(int höjd, int bredd, string levelNamn)
        {
            this.höjd = höjd;
            this.bredd = bredd;
            this.levelNamn = levelNamn;
            this.kvadrater = new Kvadrat[höjd, bredd];

            for (int i = 0; i < kvadrater.GetLength(0); i++)
            {
                for (int j = 0; j < kvadrater.GetLength(1); j++)
                {
                    kvadrater[i, j] = new Kvadrat();
                }
            }

            Random rng = new Random();

            for (int i = 1; i <= 3; i++)
            {
                int randomY = rng.Next(1, kvadrater.GetLength(0));
                int randomX = rng.Next(1, kvadrater.GetLength(1));

                kvadrater[randomY, randomX].Monster = true;
                kvadrater[randomY, randomX].Fiende = new Fiende(rng.Next(0, 4));
            }

            for (int i = 1; i <= 3; i++)
            {
                int randomY = rng.Next(1, kvadrater.GetLength(0));
                int randomX = rng.Next(1, kvadrater.GetLength(1));
                kvadrater[randomY, randomX].Kista = true;
            }


            kvadrater[0, 0].Spelare = true;
        }

        public Level()
        {
        }


        public static void Print(Level level, Spelare spelare)
        {
            Console.Clear();
            Kvadrat[,] levelInnehåll = level.kvadrater;
            Console.WriteLine($"{level.levelNamn}  Score: {Spelare.Score}");
            for (int i = -1; i <= levelInnehåll.GetLength(0); i++)
            {
                for (int j = -1; j <= levelInnehåll.GetLength(1); j++)
                {

                    if (i == -1)
                    {
                        if (j == -1)
                        {
                            Console.Write("╔");
                        }

                        if (j > -1 && j < levelInnehåll.GetLength(1))
                        {
                            Console.Write("═");
                        }

                        if (j == levelInnehåll.GetLength(1))
                        {
                            Console.Write("╗");
                        }
                    }

                    else if (j == -1 && i != -1 && i != levelInnehåll.GetLength(0) || j == levelInnehåll.GetLength(1) && i != -1 && i != levelInnehåll.GetLength(0))
                    {
                        Console.Write("║");
                    }

                    else if (i == levelInnehåll.GetLength(0))
                    {
                        if (j == -1)
                        {
                            Console.Write("╚");
                        }

                        if (j > -1 && j < levelInnehåll.GetLength(1))
                        {
                            Console.Write("═");
                        }

                        if (j == levelInnehåll.GetLength(1))
                        {
                            Console.Write("╝");
                        }
                    }

                    else if (levelInnehåll[i, j].Monster)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("☻");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if (levelInnehåll[i, j].Kista)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("■");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if (levelInnehåll[i, j].Spelare)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("☻");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
            PrintStats(spelare);
        }

        public static void PrintStats(Spelare spelare)
        {
            Console.Write("╔");

            for (int i = 0; i < spelare.Namn.Length + spelare.PlayerLevel.ToString().Length + Spelare.Hp.ToString().Length + spelare.Ras.Length + 25; i++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╗");


            Console.Write($"║");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LVL");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($": { spelare.PlayerLevel}│");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"NAME");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($": { spelare.Namn}│");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"HP");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($": {Spelare.Hp}│");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Race: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{spelare.Ras}");
            Console.Write($" ║");
            Console.WriteLine();

            Console.Write("╚");

            for (int i = 0; i < spelare.Namn.Length + +spelare.PlayerLevel.ToString().Length + Spelare.Hp.ToString().Length + spelare.Ras.Length + 25; i++)
            {
                Console.Write("═");
            }

            Console.Write("╝");

        }
        public static void MovePlayer(Level level, Spelare spelare)
        {
            Kvadrat[,] kvadratArray = level.kvadrater;

            ConsoleKeyInfo input = Console.ReadKey();

            try
            {
                for (int i = 0; i < kvadratArray.GetLength(0); i++)
                {
                    for (int j = 0; j < kvadratArray.GetLength(1); j++)
                    {
                        if (kvadratArray[i, j].Spelare)
                        {
                            currentYPos = i;
                            currentXPos = j;
                            kvadratArray[i, j].Spelare = false;
                        }
                    }
                }

                if (input.Key == ConsoleKey.UpArrow)
                {
                    currentYPos--;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }

                if (input.Key == ConsoleKey.RightArrow)
                {
                    currentXPos++;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }

                if (input.Key == ConsoleKey.DownArrow)
                {
                    currentYPos++;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }

                if (input.Key == ConsoleKey.LeftArrow)
                {
                    currentXPos--;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }

                Event(level, spelare);
                Print(level, spelare);
            }
            catch (IndexOutOfRangeException)
            {
                if (input.Key == ConsoleKey.UpArrow)
                {
                    currentYPos++;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }

                if (input.Key == ConsoleKey.RightArrow)
                {
                    currentXPos--;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }

                if (input.Key == ConsoleKey.DownArrow)
                {
                    currentYPos--;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }

                if (input.Key == ConsoleKey.LeftArrow)
                {
                    currentXPos++;
                    kvadratArray[currentYPos, currentXPos].Spelare = true;
                }
            }
        }

        public static void MoveEnemies(Level level)
        {
            for (int i = 0; i < level.kvadrater.GetLength(0); i++)
            {
                for (int j = 0; j < level.kvadrater.GetLength(1); j++)
                {
                    if (level.kvadrater[i, j].Monster)
                    {
                        Random rng = new Random();

                        int randomDir = rng.Next(1, 5);
                        Console.WriteLine(randomDir);
                        if (randomDir == 1 && i != 0) //Upp
                        {
                            try
                            {

                                if (!level.kvadrater[i - 1, j].Monster && !level.kvadrater[i - 1, j].Kista)
                                {
                                    level.kvadrater[i - 1, j].Fiende = level.kvadrater[i, j].Fiende;
                                    level.kvadrater[i, j].Fiende = null;
                                    level.kvadrater[i, j].Monster = false;
                                    level.kvadrater[i - 1, j].Monster = true;

                                }
                            }

                            catch (IndexOutOfRangeException)
                            {

                            }
                        }

                        else if (randomDir == 2 && j != level.kvadrater.GetLength(1)) //Höger
                        {
                            try
                            {
                                if (!level.kvadrater[i, j + 1].Monster && !level.kvadrater[i, j + 1].Kista)
                                {
                                    level.kvadrater[i, j + 1].Fiende = level.kvadrater[i, j].Fiende;
                                    level.kvadrater[i, j].Fiende = null;
                                    level.kvadrater[i, j].Monster = false;
                                    level.kvadrater[i, j + 1].Monster = true;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {

                            }
                        }

                        else if (randomDir == 3 && i != level.kvadrater.GetLength(0) + 1) //Ner
                        {
                            try
                            {
                                if (!level.kvadrater[i + 1, j].Monster && !level.kvadrater[i + 1, j].Kista)
                                {
                                    level.kvadrater[i + 1, j].Fiende = level.kvadrater[i, j].Fiende;
                                    level.kvadrater[i, j].Fiende = null;
                                    level.kvadrater[i, j].Monster = false;
                                    level.kvadrater[i + 1, j].Monster = true;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {

                            }
                        }

                        else if (randomDir == 4 && j != 0) //vänster
                        {
                            try
                            {
                                if (!level.kvadrater[i, j - 1].Monster && !level.kvadrater[i, j - 1].Kista)
                                {
                                    level.kvadrater[i, j - 1].Fiende = level.kvadrater[i, j].Fiende;
                                    level.kvadrater[i, j].Fiende = null;
                                    level.kvadrater[i, j].Monster = false;
                                    level.kvadrater[i, j - 1].Monster = true;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {

                            }
                        }
                    }
                }


            }

        }

        public static void Event(Level level, Spelare spelare)
        {
            Kvadrat[,] kvadratArray = level.kvadrater;

            for (int i = 0; i < kvadratArray.GetLength(0); i++)
            {
                for (int j = 0; j < kvadratArray.GetLength(1); j++)
                {
                    if (kvadratArray[i, j].Monster && kvadratArray[i, j].Spelare)
                    {
                        Fight(kvadratArray[i, j], spelare);
                    }


                    if (kvadratArray[i, j].Kista && kvadratArray[i, j].Spelare)
                    {
                        Collect(kvadratArray[i, j]);
                    }
                }
            }
        }

        private static void Collect(Kvadrat kvadrat)
        {
            Spelare.Score += 50;
            kvadrat.Kista = false;
        }

        private static void Fight(Kvadrat kvadrat, Spelare spelare)
        {
            bool fight = true;

            while (fight)
            {
                Console.Clear();
                DrawFight(kvadrat, spelare);
            }

        }

        public static void PrintEnemy(Kvadrat kvadrat)
        {

            int namnLängd = kvadrat.Fiende.FiendeTyp.Length;

            Console.Write("╔");

            for (int i = 0; i < namnLängd + 4; i++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╗");

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.Write("║");
                }

                if (i == 1)
                {
                    Console.Write($"  {kvadrat.Fiende.FiendeTyp}  ");
                }

                if (i == 2)
                {
                    Console.WriteLine("║");
                }
            }



            Console.Write("╚");

            for (int i = 0; i < namnLängd + 4; i++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╝");


            int initialHp = kvadrat.Fiende.Hp;

            Console.Write("╔");

            for (int i = 0; i < initialHp * 2 + 1; i++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╗");


            for (int i = 0; i < kvadrat.Fiende.Hp; i++)
            {
                if (i == 0)
                {
                    Console.Write("║");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" ♥");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("");

                if (i == kvadrat.Fiende.Hp - 1)
                {
                    Console.Write(" ║");
                }
            }

            Console.WriteLine();

            Console.Write("╚");

            for (int i = 0; i < initialHp * 2 + 1; i++)
            {
                Console.Write("═");
            }

            Console.Write("╝");

            Console.WriteLine();

            if (kvadrat.Fiende.FiendeTyp == "Slime")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{kvadrat.Fiende.FiendeGrafik}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (kvadrat.Fiende.FiendeTyp == "King-Slime")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{kvadrat.Fiende.FiendeGrafik.Substring(0, 55)}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{kvadrat.Fiende.FiendeGrafik.Substring(55)}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (kvadrat.Fiende.FiendeTyp == "Witch")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{kvadrat.Fiende.FiendeGrafik.Substring(0, 84)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{kvadrat.Fiende.FiendeGrafik.Substring(84)}");
            }

            if (kvadrat.Fiende.FiendeTyp == "Angry-Witch")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{kvadrat.Fiende.FiendeGrafik.Substring(0, 130)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{kvadrat.Fiende.FiendeGrafik.Substring(130)}");
            }

            Console.WriteLine("═══════════════════════════════════════════════════");
        }

        private static void DrawFight(Kvadrat kvadrat, Spelare spelare)
        {
            PrintEnemy(kvadrat);
            PrintStats(spelare);
            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════╗");
            for (int i = 0; i < fightMeny.GetLength(0); i++)
            {
                Console.Write("   ");

                if (fightMeny[i, 1] == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(fightMeny[i, 0]);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(fightMeny[i, 0]);
                }
            }

            Console.WriteLine();
            Console.WriteLine("╚════════════════════════════════╝");

            Console.WriteLine();

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.RightArrow && fightMenyVal != 3)
            {
                fightMeny[fightMenyVal, 1] = "0";
                fightMenyVal++;
                fightMeny[fightMenyVal, 1] = "1";
            }


            if (input.Key == ConsoleKey.LeftArrow && fightMenyVal != 0)
            {
                fightMeny[fightMenyVal, 1] = "0";
                fightMenyVal--;
                fightMeny[fightMenyVal, 1] = "1";
            }

            if (input.Key == ConsoleKey.Enter)
            {
                if (fightMenyVal == 0)
                {
                    Attack(kvadrat);
                }

                else if (fightMenyVal == 1)
                {

                    Spelare.Inventory[0].Vald = true;

                    bool vald = false;

                    int menyVal = 0;

                    while (!vald)
                    {
                        Console.Clear();
                        PrintEnemy(kvadrat);
                        PrintStats(spelare);
                        Console.WriteLine();
                        spelare.PrintInventory();


                        ConsoleKeyInfo input2 = Console.ReadKey(true);

                        if (input2.Key == ConsoleKey.UpArrow)
                        {
                            if (menyVal != 0)
                            {
                                Spelare.Inventory[menyVal].Vald = false;
                                menyVal--;
                                Spelare.Inventory[menyVal].Vald = true;

                                Console.Beep(300, 100);
                            }
                        }

                        if (input2.Key == ConsoleKey.DownArrow)
                        {
                            if (menyVal < Spelare.Inventory.Count - 1)
                            {
                                Spelare.Inventory[menyVal].Vald = false;
                                menyVal++;
                                Spelare.Inventory[menyVal].Vald = true;

                                Console.Beep(300, 100);
                            }
                        }

                        if (input2.Key == ConsoleKey.Enter)
                        {
                            Spelare.Inventory[menyVal].AnvändFöremål(kvadrat);
                            vald = true;
                        }

                        Console.Clear();
                    }
                }

                else if (fightMenyVal == 2)
                {

                }

                else
                {

                }
            }

        }

        private static void Attack(Kvadrat kvadrat)
        {
            throw new NotImplementedException();
        }

        public int Höjd { get { return this.höjd; } set { this.höjd = value; } }
        public int Bredd { get { return this.bredd; } set { this.bredd = value; } }

        public string LevelNamn { get { return this.levelNamn; } set { this.levelNamn = value; } }

        public Kvadrat[,] Kvadrater { get { return this.kvadrater; } set { this.kvadrater = value; } }


    }
}
