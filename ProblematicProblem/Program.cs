using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {       
        public bool cont = true;
        static List<string> activities = new List<string>()
        { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.WriteLine("Hello, welcome to the random activity generator!");
            Console.WriteLine("Would you like to generate a random activity? yes/no");
            bool cont = (Console.ReadLine().ToLower() == "yes")? true : false;
            Console.WriteLine();

            while (cont == true)
            {
                Console.WriteLine("We are going to need your information first! What is your name?");
                string userName = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Would you like to see the current list of activities? yes/no");
                bool seeList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                if (seeList == true)
                {
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"{activity}");
                        Thread.Sleep(250);
                    }
                }
                Console.WriteLine();

                Console.WriteLine("Would you like to add any activities before we generate one? yes/no");
                bool addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                Console.WriteLine();
                if (addToList == true)
                {
                    Console.WriteLine("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    Console.WriteLine();
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Would you like to add more? yes/no");
                    bool addMoreToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                    while (addMoreToList == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("What would you like to add?");
                        activities.Add(Console.ReadLine());
                        Console.WriteLine();
                        foreach (string activity in activities)
                        {
                            Console.WriteLine($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no");
                        addMoreToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                    }
                    Console.WriteLine();
                }

                while (cont == true)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();

                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];

                    if (userAge > 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);

                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}!");
                    Console.WriteLine();
                    Console.WriteLine("Is this ok or do you want to grab another activity? Keep/Redo");
                    cont = (Console.ReadLine().ToLower() == "redo") ? true : false;
                }

            } 
        }
    }
}