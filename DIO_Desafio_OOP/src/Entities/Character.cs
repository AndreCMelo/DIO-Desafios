namespace DIO_Desafio_OOP.src.Entities
{
    public class Character
    {
        public Character(string name, int level, string heroType, int hp, int mp)
        {
            this.name = name;
            this.level = level;
            this.heroType = heroType;
            this.hp = hp;
            this.mp = mp;
        }
        public string name, heroType;
        public int level, hp, mp;

        public override string ToString()
        {
            return $@"
              {this.name}       
                Lv. {this.level} {this.heroType}   
                HP  {this.hp} / {this.hp}       
                MP  {this.mp} / {this.mp}
                ";    
        }
    }
}