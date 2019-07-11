using System;
using System.Collections.Generic;

namespace Hungry_ninja
{
    class Program
    {
        class Food
        {
            public string Name;
            public int Calories;
            public bool IsSpicy;
            public bool IsSweet;

            public Food(string name, int calories, bool is_spicy, bool is_sweet)
            {
                Name = name;
                Calories = calories;
                IsSpicy = is_spicy;
                IsSweet = is_sweet;
            }
        }
        class Buffet {
            public List<Food> Menu;

            public Buffet()
            {
                Menu = new List<Food>();
                {
                    Menu.Add(new Food("Fish", 1000, false, true));
                    Menu.Add(new Food("Rise", 500, true, false));
                    Menu.Add(new Food("Meat", 2000, false, true));
                    Menu.Add(new Food("Pie", 100, true, false));
                };
            }
            public Food Serve()
            {
                Random rand = new Random();
                return Menu[rand.Next(0,Menu.Count)];
            }
        }
        class Ninja
        {
            private int calorieIntake;
            public List<Food> FoodHistory;
            public Ninja()
            {
                calorieIntake = 0;
                FoodHistory = new List<Food>();
            }
            public bool IsFull
            {
                get
                {
                    if(calorieIntake > 3000)
                    {
                        Console.WriteLine($"Ninja get {calorieIntake} kcal!");
                        Console.WriteLine("I'm full!");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            public void Eat(Food item)
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item); 
            }
            
        }
        static void Main(string[] args)
        {
            Buffet ninja_1 = new Buffet();
            Ninja ninja_2 = new Ninja();
            while(!ninja_2.IsFull)
            {
                ninja_2.Eat(ninja_1.Serve());
            }
        }
    }
}
