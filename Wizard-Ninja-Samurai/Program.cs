using System;

namespace Wizard_Ninja_Samurai
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
         
        public int Health
        {
            get { return health; }
        }
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
         
        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }
         
        // Build Attack method
        public virtual int Attack(Human target)
        {
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }

        public int TakeDamage(int dmg)
        {
            this.health -= dmg;
            return this.health;
        }

        public int GainHealth(int hp)
        {
            this.health += hp;
            return this.health;
        }
    }
    
    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Intelligence = 25;
            health = 50;
        }

        public override int Attack(Human target)
        {
            int dmg = 5 * Intelligence;
            this.health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.TakeDamage(dmg);
        }

        public int Heal(Human target)
        {
            int hp = 10 * Intelligence;
            System.Console.WriteLine($"{Name} healed {target.Name} for {hp}hp!");
            return target.GainHealth(hp);
        }
    }
    

    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            int dmg = 5 * Dexterity;
            Random rand = new Random();
            if (rand.Next(0,5) < 1) { dmg += 10; }
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.TakeDamage(dmg);
        }

        public int Steal(Human target)
        {
            int dmg = 5;
            this.health += dmg;
            Console.WriteLine($"{Name} stole {dmg} hp from {target.Name}!");
            return target.TakeDamage(dmg);
        }
    }

    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }

        public override int Attack(Human target)
        {
            base.Attack(target);
            if (target.Health < 50) { target.TakeDamage(target.Health); }
            Console.WriteLine($"{Name} attacked {target.Name}! {target.Name} has {target.Health}hp remaining!");
            return target.Health;
        }

        public int Meditate()
        {
            this.health = 200;
            System.Console.WriteLine($"{Name} is meditating.");
            return this.health;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Human person_1 = new Human("person_1");
            Ninja person_2 = new Ninja("person_2");
            Wizard person_3 = new Wizard("person_3");
            Samurai person_4 = new Samurai("person_4");
            person_4.Attack(person_1);
            System.Console.WriteLine(person_1.Health);
            person_3.Heal(person_1);
            person_3.Heal(person_1);
            person_2.Steal(person_1);
            person_3.Attack(person_1);
            System.Console.WriteLine($"How is {person_1.Name} doing? HP: {person_1.Health}");
        }
    }
}
