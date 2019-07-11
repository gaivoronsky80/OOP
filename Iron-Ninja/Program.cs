using System;
using System.Collections.Generic;

namespace Iron_Ninja
{
    interface IConsumable
    {
        string Name {get;set;}
        int Calories {get;set;}
        bool IsSpicy {get;set;}
        bool IsSweet {get;set;}
        string GetInfo();
    }
    class Food : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo()
        {
            return $"{Name}: (Food). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Food(string name, int cal, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }
    class Drink : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public Drink(string name, int cal)
        {
            Name = name;
            Calories = cal;
            IsSpicy = false;
            IsSweet = true;
        }
        public string GetInfo()
        {
            return $"{Name}: (Drink). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
    }
    class Buffet
    {
        public List<Food> Menu;
        public Buffet()
        {
            Menu = new List<Food>();
            {
                Menu.Add(new Food("Tofu", 200, false, false));
                Menu.Add(new Food("Fish", 500, true, false));
                Menu.Add(new Food("Meat", 700, false, true));
                Menu.Add(new Food("Salad", 100, true, false));
            };
        }
        public Food Serve()
        {
            Random rand = new Random();
            return Menu[rand.Next(0,Menu.Count)];
        }
    }
    abstract class Ninja
    {
        protected int calorieIntake;
        public List<IConsumable> ConsumptionHistory;
        public Ninja()
        {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
        public abstract bool IsFull{get;}
        public abstract void Consume(IConsumable item);
    }
    class SweetTooth : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if(calorieIntake >= 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public override void Consume(IConsumable item)
        {
            if (!IsFull)
            {
                calorieIntake += item.Calories;
                if(item.IsSweet)
                {
                    calorieIntake += 10;
                }
                ConsumptionHistory.Add(item);
                Console.WriteLine(item.GetInfo());
            }
            else
            {
                Console.WriteLine("I am full!");
            }
        }
    }
    class SpiceHound : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if(calorieIntake >= 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public override void Consume(IConsumable item)
        {
            if(!IsFull)
            {
                calorieIntake += item.Calories;
                if(item.IsSpicy)
                {
                    calorieIntake -= 5;
                }
                ConsumptionHistory.Add(item);
                Console.WriteLine(item.GetInfo());
            }
            else
            {
                Console.WriteLine("I am full!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Buffet person_1 = new Buffet();
            SweetTooth person_2 = new SweetTooth();
            SpiceHound person_3 = new SpiceHound();
            person_2.Consume(person_1.Serve());
            person_3.Consume(person_1.Serve());
        }
    }
}
