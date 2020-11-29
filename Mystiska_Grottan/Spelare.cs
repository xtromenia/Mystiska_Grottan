using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mystiska_Grottan
{
    public class Spelare
    {
        private static int score;
        private static int hp, attack;
        private int playerLevel;
        private static string namn, ras;
        private static List<Föremål> inventory = new List<Föremål>();


        public Spelare(string inputNamn, string inputRas)
        {
            score = 0;
            this.playerLevel = 1;
            namn = inputNamn;
            ras = inputRas;

            if (ras == "Human")
            {
                hp = 2;
                attack = 20;
            }

            if (ras == "Dwarf")
            {
                hp = 120;
                attack = 15;
            }

            if (ras == "Orc")
            {
                hp = 60;
                attack = 35;
            }

            if (ras == "Elf")
            {
                hp = 80;
                attack = 25;
            }

            for (int i = 0; i < 2; i++)
            {
                LäggTillFöremål(new Föremål("Health Potion"));
            }

            LäggTillFöremål(new Föremål("Bomb"));
        }

        public void LäggTillFöremål(Föremål item)
        {
            inventory.Add(item);
        }

        public void TaBortFöremål(Föremål item)
        {
            inventory.Remove(item);
        }

        public int RäknaFöremål(Föremål itemAttRäkna)
        {
            int antal = 0;

            foreach (Föremål item in inventory)
            {
                if (item.Namn == itemAttRäkna.Namn)
                {
                    antal++;
                }
            }

            return antal;
        }

        public void PrintInventory()
        {
            int längd = GetLängst();
            int antalMellanslag = 0;

            for (int i = 0; i < längd + 4; i++)
            {
                if (i == 0)
                {
                    Console.Write("╔");
                }

                else if (i == längd + 3)
                {
                    Console.Write("╗");
                }

                else
                {
                    Console.Write("═");
                }
            }

            Console.WriteLine();

            for (int i = 0; i < inventory.Count; i++)
            {
                Console.Write("║");
                antalMellanslag = längd - inventory[i].Namn.Length;

                if (inventory[i].Vald)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" " + inventory[i].Namn + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else if (inventory[i].Exit)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" " + inventory[i].Namn + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" " + inventory[i].Namn + " ");
                }

                for (int j = 0; j < antalMellanslag; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("║");
            }

            for (int i = 0; i < längd + 4; i++)
            {
                if (i == 0)
                {
                    Console.Write("╚");
                }

                else if (i == längd + 3)
                {
                    Console.Write("╝");
                }

                else
                {
                    Console.Write("═");
                }
            }
        }

        public int GetLängst()
        {
            int längd = 0;

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Namn.Length > längd)
                {
                    längd = inventory[i].Namn.Length;
                }
            }

            return längd;
        }

        public static string Ras
        {
            get { return ras; }
            set { ras = value; }
        }

        public static int Score
        {
            get { return score; }
            set { score = value; }
        }

        public static int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public int PlayerLevel
        {
            get { return this.playerLevel; }
            set { this.playerLevel = value; }
        }

        public static string Namn
        {
            get { return namn; }
            set { namn = value; }
        }

        public static int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public static List<Föremål> Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

    }
}
