using System;

namespace Mystiska_Grottan
{
    public class Föremål
    {
        private string namn;
        private int värde;
        private bool vald, exit;


        public bool Vald
        {
            get { return vald; }
            set { vald = value; }
        }

        public string Namn
        {
            get { return this.namn; }
            set { this.namn = value; }
        }

        public int Värde
        {
            get { return this.värde; }
            set { this.värde = value; }
        }


        public bool Exit { get { return this.exit; } set { this.exit = value; } }

        public Föremål(string namn)
        {
            this.namn = namn;

            if (namn == "Health Potion")
            {
                this.värde = 50;
            }

            if (namn == "Bomb")
            {
                this.värde = 150;
            }

            if (namn == "Exit")
            {
                this.exit = true;
            }
        }

        public void AnvändFöremål(Kvadrat kvadrat)
        {

            if (this.namn == "Exit")
            {
            }

            else
            {
                Spelare.Inventory.Remove(this);

                if (namn == "Health Potion")
                {
                    Spelare.Hp += 50;
                    Console.Beep(200, 300);
                }

                if (namn == "Bomb")
                {
                    kvadrat.Fiende.Hp -= 2;
                    Console.Beep(37, 300);
                }

            }

        }
    }
}