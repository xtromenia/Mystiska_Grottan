namespace Mystiska_Grottan
{
    public class Fiende
    {
        string fiendeTyp, fiendeGrafik;
        int hp, attack;
        public Fiende(int fiendeTyp)
        {
            if (fiendeTyp == 0)
            {
                this.fiendeTyp = "Slime";
                this.hp = 3;
                this.attack = 5;
                this.fiendeGrafik = @"
   ■■■■■■■■■■■■■■■
  ■■■■■■■■■■■■■■■■■
 ■■■■■■■■■■■■■■■■■■■	
■■■■  ■■■■■■■■■■  ■■■ 
■■■■  ■■■■■■■■■■  ■■■
 ■■■■■■■■■■■■■■■■■■■
  ■■■■■■■■■■■■■■■■■
   ■■■■■■■■■■■■■■■";
            }

            if (fiendeTyp == 1)
            {
                this.fiendeTyp = "King-Slime";
                this.hp = 5;
                this.attack = 7;
                this.fiendeGrafik = @"
      ■   ■   ■
      ■   ■   ■	
     ■■■ ■■■ ■■■
   ■■■■■■■■■■■■■■■
  ■■■■■■■■■■■■■■■■■
 ■■■■■■■■■■■■■■■■■■■	
■■■■  ■■■■■■■■■■  ■■■ 
■■■■  ■■■■■■■■■■  ■■■
 ■■■■■■■■■■■■■■■■■■■
  ■■■■■■■■■■■■■■■■■
   ■■■■■■■■■■■■■■■";
            }

            if (fiendeTyp == 2)
            {
                this.fiendeTyp = "Witch";
                this.hp = 4;
                this.attack = 6;
                this.fiendeGrafik = @"
        ▄
       █▒█▄  
      ▄█▓▓▒█▄
    ▄█▓▓▓▓▓▒▒█▄
▄▄▄█▓▓▓▓▓▓▓▓▓▒▒█▄▄▄ 
   █  ▲     ▲  █
   █ ░░  █  ░░ █
   █   ▬▬▬▬▬   █
   ▀▄▄       ▄▄▀
      ▀▀▀▀▀▀▀";

            }

            if (fiendeTyp == 3)
            {
                this.fiendeTyp = "Angry-Witch";
                this.hp = 4;
                this.attack = 6;
                this.fiendeGrafik = @"
 ░        █ 
           █      ░
   ░   █  █▒█▄ █ 
       █▄█▓▓▒█▄█     ░
░     ▄█▓▓▓▓▓▒▒█▄
▄▄▄▄▄█▓▓▓▓▓▓▓▓▓▒▒█▄▄▄▄▄ 
     █  ►     ◄  █
     █ ▒▒▒ ▀ ▒▒▒ █  ░
  ░  █   ▄███▄   █
     ▀▄▄       ▄▄▀    ░  
        ▀▀▀▀▀▀▀";
            }

        }

        public string FiendeGrafik { get { return this.fiendeGrafik; } set { this.fiendeGrafik = value; } }

        public string FiendeTyp { get { return this.fiendeTyp; } set { this.fiendeTyp = value; } }

        public int Hp { get { return this.hp; } set { this.hp = value; } }
    }
}