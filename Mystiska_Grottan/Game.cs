using System;
using System.Media;

namespace Mystiska_Grottan
{
    public class Game
    {

        static bool spela = false;
        static Spelare spelare;
        static void Main(string[] args)
        {

            Meny();

            bool validInput = false;

            while (!validInput)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.D1)
                {
                    SkapaKaraktär();
                    validInput = true;
                }

                if (input.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    validInput = true;
                    Rules();
                }

                if (input.Key == ConsoleKey.D3)
                {
                    validInput = true;
                    Environment.Exit(0);
                }
            }

            Level level1 = new Level(5, 15, "Level 1");
            Level.Print(level1, spelare);

            while (spela)
            {
                Level.MovePlayer(level1, spelare);
                Level.MoveEnemies(level1);
            }

        }

        private static void SkapaKaraktär()
        {
            string[,] rasVal = { { "Human", "1" }, { "Dwarf", "0" }, { "Elf", "0" }, { "Orc", "0" } };
            int menyVal = 0;
            bool inmatning = false;

            while (!inmatning)
            {
                Console.Clear();

                Console.WriteLine("╔═══════════════╗");
                for (int i = 0; i < rasVal.GetLength(0); i++)
                {
                    if (rasVal[i, 1] == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("     " + " ► ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(rasVal[i, 0]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" ◄ ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     " + rasVal[i, 0]);
                    }
                }
                Console.WriteLine("╚═══════════════╝");

                if (menyVal == 0)
                {
                    Console.WriteLine("╔════════════════════════════════╗");
                    Console.WriteLine("║ The Human race is average when ║");
                    Console.WriteLine("║ it comes to health and attack  ║");
                    Console.WriteLine("╚════════════════════════════════╝");
                }

                if (menyVal == 1)
                {
                    Console.WriteLine("╔═══════════════════════════════════════════════════╗");
                    Console.WriteLine("║ The dwarven race is slightly bulky, the bulkiness ║");
                    Console.WriteLine("║ slightly increases HP but decreases attack.       ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════╝");
                }

                if (menyVal == 2)
                {
                    Console.WriteLine("╔═══════════════════════════════════════════════════╗");
                    Console.WriteLine("║ The elven race is less bulky, less bulkiness      ║");
                    Console.WriteLine("║ results in decreased HP but increased attack.     ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════╝");
                }

                if (menyVal == 3)
                {
                    Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║ The orcish race is very strong but lack armour, this results ║");
                    Console.WriteLine("║ in vastly decreased HP but it vastly increases attack.       ║");
                    Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
                }

                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.UpArrow && menyVal != 0)
                {
                    rasVal[menyVal, 1] = "0";
                    menyVal--;
                    rasVal[menyVal, 1] = "1";
                }


                if (input.Key == ConsoleKey.DownArrow && menyVal != 3)
                {
                    rasVal[menyVal, 1] = "0";
                    menyVal++;
                    rasVal[menyVal, 1] = "1";
                }

                if (input.Key == ConsoleKey.Enter)
                {
                    inmatning = true;
                    string valdRas = rasVal[menyVal, 0];
                    Console.WriteLine("Enter your name: ");
                    string namn = Console.ReadLine();
                    spelare = new Spelare(namn, valdRas);
                    spela = true;
                }
            }
        }

        private static void Rules()
        {

            Console.WriteLine("╔════════════════╗");
            Console.Write("║"); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" ■"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" - Chest      ║");
            Console.Write("║"); Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ☻"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" - Player     ║");
            Console.Write("║"); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write(" ☻"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" - Enemy      ║");
            Console.WriteLine("║                ║");
            Console.WriteLine("║ Collect loot   ║");
            Console.WriteLine("║ Kill Enemies   ║");
            Console.WriteLine("║ Try to survive!║");
            Console.WriteLine("╚════════════════╝");

            Meny();

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.D1)
            {
                SkapaKaraktär();
            }

            if (input.Key == ConsoleKey.D3)
            {
                Environment.Exit(0);
            }
            Console.ReadKey();
        }

        public static void Meny()
        {
            Console.WriteLine("╔══════════╗");
            Console.WriteLine("║[1] Play  ║");
            Console.WriteLine("║[2] Rules ║");
            Console.WriteLine("║[3] Quit  ║");
            Console.WriteLine("╚══════════╝");
        }

        public static Spelare Spelare { get { return spelare; } }
    }
}
