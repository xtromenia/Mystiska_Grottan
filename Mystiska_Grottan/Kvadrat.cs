using System;

namespace Mystiska_Grottan
{
    public class Kvadrat
    {
        private bool monsterBool, kistaBool, spelareBool;
        private static int antalMonster = 0;
        private static int antalKistor = 0;

        private Spelare spelare;
        private Fiende fiende;
        private Kista kista;

        public Kvadrat()
        {

        }

        public bool Monster { get { return this.monsterBool; } set { this.monsterBool = value; } }
        public bool Spelare { get { return this.spelareBool; } set { this.spelareBool = value; } }
        public bool Kista { get { return this.kistaBool; } set { this.kistaBool = value; } }

        public Fiende Fiende { get { return this.fiende; } set { this.fiende = value; } }
    }
}