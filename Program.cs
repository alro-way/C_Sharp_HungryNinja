using System;
using System.Collections.Generic;

namespace C_Sharp_HungryNinja
{
    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy; 
        public bool IsSweet; 
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string Fname, int FCalo, bool FSpicy, bool FSweet)
        {
            this.Name = Fname;
            this.Calories = FCalo;
            this.IsSpicy = FSpicy;
            this.IsSweet = FSweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;
        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Borch", 1800, true, false),
                new Food("Tea", 10, false, false),
                new Food("Blueberry", 30, false, true),
                new Food("Eggs fried", 400, false, false),
                new Food("Soup", 1500, true, false),
                new Food("Sushi", 1200, true, false),
                new Food("Bread", 600, false, false),
                new Food("Jam", 10, false, true)
            };
        }
        
        public Food Serve()
        {
            Random RandFood = new Random();
            int randInt = RandFood.Next(Menu.Count);
            return Menu[randInt];
        }
    }

    class Ninja
    {
        public string Name;
        private int calorieIntake;
        public List<Food> FoodHistory;
        
        public int CalorieProp
        {
            get
            {
                return calorieIntake;
            }
        }
        // add a constructor
        public Ninja(string Nname)
        {
            this.Name = Nname;
            this.calorieIntake = 0;
            this.FoodHistory = new List<Food>();
        }
        

        // add a public "getter" property called "IsFull"
        public bool IsFull 
        {
            get
            {
                if (this.calorieIntake > 1200)
                {
                    Console.WriteLine("Is FULL");
                    return true;
                }
                Console.WriteLine("Is Hugry");
                return false;
            }
        }
        
        // build out the Eat method
        public void Eat(Food item)
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine($"Food name: {item.Name}, Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var NewFood1 = new Food("Cake", 200, false, true);
            Console.WriteLine($"This {NewFood1.Name} is great!");
            Buffet CoolMenu = new Buffet();
            CoolMenu.Serve();
            Console.WriteLine($"Random food is '{CoolMenu.Serve().Name}'");
            // Console.WriteLine($"{Ninja.IsFull}");
            var NewNinja = new Ninja("Djo");
            Console.WriteLine($"This {NewNinja.Name} Welcome!");
            // NewNinja.Eat(CoolMenu.Serve());
            Console.WriteLine($"{NewNinja.CalorieProp}");

            while (NewNinja.IsFull == false)
            {
                NewNinja.Eat(CoolMenu.Serve());
            }
            Console.WriteLine($"Warning: calorie intake is {NewNinja.CalorieProp}. The ninja is full and cannot eat anymore!");
        }
    }
}
