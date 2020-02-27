using System;

namespace PartyThyme
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new PlantContext();
      var work = new GardenMaster();
      var isRunning = true;

      Console.WriteLine("Welcome to the garden! Please (select) an option");
      // Options
      while (isRunning == true)
      {

        Console.WriteLine("(VIEW) all plants");
        Console.WriteLine("(ADD) a plant");
        Console.WriteLine("(REMOVE) a plant");
        Console.WriteLine("(WATER) a plant");
        Console.WriteLine("(LOG) view the water log to find which plants need watering");
        Console.WriteLine("(YARD) view a summary of plant locations");
        Console.WriteLine("(QUIT) close this program");
        var input = Console.ReadLine().ToLower();
        // Methods adding plants
        if (input == "add")
        {
          work.DigAHole();
        }
        else if (input == "remove")
        {
          work.PullAPlant();
        }
        else if (input == "view")
        {
          work.SeeTheFlowers();
        }
        else if (input == "water")
        {
          work.MakeItRain();
        }
        else if (input == "log")
        {
          work.SeeThirstyBoys();
        }
        else if (input == "yard")
        {
          work.MilkshakesInTheYard();
        }

        else if (input == "quit")
        {

          isRunning = false;
          Console.WriteLine("Goodbye!");
          Console.ReadLine();
        }
        else
        {
          Console.WriteLine("I'm sorry, I couldn't understand. Please try again.");
        }

      }

    }
  }
}
