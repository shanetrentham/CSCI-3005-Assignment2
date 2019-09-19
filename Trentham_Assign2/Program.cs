using System;

namespace Trentham_Assign2
{

    class MainClass
    {
        

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Spaceship builder!");
            Console.WriteLine("Enter the name of the spaceship: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the capacity of the spaceship");
            int capacity = int.Parse(Console.ReadLine());

            Spaceship spaceship = new Spaceship(name, capacity);

            int choice = 0;
            while (choice != 7)
            {
                Console.WriteLine("1. Add an Alien");
                Console.WriteLine("2. Get the number of Aliens in the spaceship");
                Console.WriteLine("3. Find the oldest Alien");
                Console.WriteLine("4. Find the oldest Alien of a color");
                Console.WriteLine("5. Get the count of good Aliens");
                Console.WriteLine("6. Get the count of bad Aliens");
                Console.WriteLine("7. Quit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Alien alien = AlienBuilder();
                            spaceship.AddAlien(alien);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("There are " + spaceship.Count() + " Aliens in the spaceship.");
                            break;
                        }
                    case 3:
                        {
                            Alien oldest = spaceship.getOldest();
                            Console.WriteLine(oldest.ToString());
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Get the oldest of which color (Red, blue, green): ");
                            string ans = Console.ReadLine();
                            Alien oldestofColor = spaceship.getOldest(ans.ToLower());
                            Console.WriteLine(oldestofColor.ToString());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("The total number of good Aliens is: " + spaceship.getGood(true));
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("The total number of bad Aliens is: " + spaceship.getGood(false));
                            break;
                        }
                    case 7:
                        {
                            System.Environment.Exit(0);
                            break;
                        }
                }
            }
        }
        public static Alien AlienBuilder()
        {
            string name, color, good, input;
            bool isGood = true;
            long age, inAge;
            Planet planet;

            Console.WriteLine("Enter the name of the Alien: ");
            input = Console.ReadLine();

            if (input == "")
                throw new Exception("The name must not be empty");
            else
                name = input;

            Console.WriteLine("Enter the color of the Alien (Red, Green, Blue): ");
            input = Console.ReadLine();

            if (input == "" || input.ToLower() != "green" && input.ToLower() != "red" && input.ToLower() != "blue")
                throw new Exception("The color must be Red, Green, or Blue.");
            else
                color = input.ToLower();

            Console.WriteLine("Enter the age of the Alien: ");
            inAge = long.Parse(Console.ReadLine());

            if (inAge < 0)
                throw new Exception("Age must not be a negative number");
            else
                age = inAge;

            Console.WriteLine("Is the Alien good or bad? ");
            good = Console.ReadLine();

            if (good.ToLower() == "good")
                isGood = true;
            else if (good.ToLower() == "bad")
                isGood = false;

            Console.WriteLine("What planet is the Alien from: ");
            
            input = Console.ReadLine();
            planet = new Planet(input);

            Alien alien = new Alien(name, color, age, isGood, planet);
            Console.WriteLine(alien.ToString());
            return alien;
        }
    }
}
