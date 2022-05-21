namespace DIO_Desafio_OOP.src.Entities
{
    public class Wizard : Character
    {
        public Wizard(string name, int level, string heroType, int hp, int mp) : base(name, level, heroType, hp, mp)
        {
            this.name = name;
            this.level = level;
            this.heroType = heroType;
            this.hp = hp;
            this.mp = mp;
        }
    }
}