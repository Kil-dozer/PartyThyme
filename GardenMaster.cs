using System;
using System.Linq;

namespace PartyThyme
{
  public class GardenMaster
  {



    public void DigAHole()
    {
      var db = new PlantContext();
      Console.WriteLine("What kind of plant would you like to add?");
      var kind = Console.ReadLine().ToLower();
      Console.WriteLine("What yard do you want to put it in?");
      Console.WriteLine("(NORTH) (SOUTH) (EAST) (WEST)");
      var home = Console.ReadLine().ToLower();
      var where = "";
      // Where is home for the plant
      if (home == "north")
      {
        where = "north";
      }
      else if (home == "south")
      {
        where = "south";
      }
      else if (home == "east")
      {
        where = "east";
      }
      else if (home == "west")
      {
        where = "west";
      }

      var creationTime = DateTime.Now;
      Console.WriteLine($"What level of light will {kind} need, on a scale of (1 = low) to (10 = high)?");
      var sunJuice = int.Parse(Console.ReadLine().ToLower());
      Console.WriteLine($"How much water will {kind} need, on a scale of (1 = low) to (10 = high)?");
      var electrolytes = int.Parse(Console.ReadLine().ToLower());

      // sum up and save to the plant db
      var photosythesisor = new Plant
      {
        Species = kind,
        PlantLocation = where,
        PlanetedDate = creationTime,
        LightLevelNeeded = sunJuice,
        WaterNeeded = electrolytes,
        LastWateredDate = DateTime.Now,
      };
      db.Plants.Add(photosythesisor);
      db.SaveChanges();
    }
    public void PullAPlant()
    {
      var db = new PlantContext();
      Console.WriteLine("What plant would you like to remove");
      var kind = Console.ReadLine().ToLower();

      // find the plant
      var photosythesisor = new Plant
      {
        Species = kind
      };
      var plantToPull = db.Plants.Where(p => p.Species == kind);

      // attempted check for repeated plants
      // if (kind.Count() > 1)
      // {
      //   var plantLineUp = db.Plants.Where(p => p.Species == kind);
      //   Console.WriteLine($"We found multiple {kind}. Which do you want to remove?");
      // foreach (var plant in plantLineUp)
      //   {
      //     var stackedPlant = plantLineUp[i];
      //     Console.WriteLine($"{i + 1}: {stackedPlant.PlantedDate}");

      //   }
      //   var index = int.Parse(Console.ReadLine());
      //   db.Plants.RemoveRange(plantLineUp[index - 1]);

      // }
      Console.WriteLine($"We've removed {kind} from the garden.");

      db.Plants.RemoveRange(plantToPull);
      db.SaveChanges();
    }
    public void SeeTheFlowers()
    {
      var db = new PlantContext();
      var allPlants = db.Plants;
      foreach (var plant in allPlants)
      {
        Console.WriteLine($"Plant type: {plant.Species}, Yard: {plant.PlantLocation}, When Planted:{plant.PlanetedDate}, Light Rrequirements: {plant.LightLevelNeeded}, Cups of Water Needed / Day: {plant.WaterNeeded}");
      }
    }
    public void MakeItRain()
    {
      var db = new PlantContext();
      Console.WriteLine("What plant would you like to water");
      var kind = Console.ReadLine().ToLower();

      // find the plant
      var photosythesisor = new Plant
      {
        Species = kind,
        LastWateredDate = DateTime.Now
      };
      var plantToUpdate = db.Plants.First(p => p.Species == kind);
      plantToUpdate.LastWateredDate = DateTime.Now;

      db.SaveChanges();

    }
    public void SeeThirstyBoys()
    {
      var db = new PlantContext();
      // var dayOfWatering = new DateTime();
      var someThirstyBoys = db.Plants.OrderBy(plant => plant.LastWateredDate);
      foreach (var plant in someThirstyBoys)
      // if
      {
        Console.WriteLine($"{plant.Species} was last watered at {plant.LastWateredDate}");
      }
    }
    public void MilkshakesInTheYard()
    {
      var db = new PlantContext();
      var allPlants = db.Plants;
      Console.WriteLine("Please (select) a yard to view");
      Console.WriteLine("(NORTH) (SOUTH) (EAST) (WEST)");
      var home = Console.ReadLine().ToLower();
      var northPlants = db.Plants.Where(plant => plant.PlantLocation == "north");
      var southPlants = db.Plants.Where(plant => plant.PlantLocation == "south");
      var eastPlants = db.Plants.Where(plant => plant.PlantLocation == "east");
      var westPlants = db.Plants.Where(plant => plant.PlantLocation == "west");
      if (home == "north")
      {
        foreach (var plant in northPlants)
          Console.WriteLine($"{plant.Species} is located in the {home} yard.");
      }
      else if (home == "south")
      {
        foreach (var plant in southPlants)
          Console.WriteLine($"{plant.Species} is located in the {home} yard.");
      }
      else if (home == "east")
      {
        foreach (var plant in eastPlants)
          Console.WriteLine($"{plant.Species} is located in the {home} yard.");
      }
      else if (home == "west")
      {
        foreach (var plant in westPlants)
          Console.WriteLine($"{plant.Species} is located in the {home} yard.");
      }

    }
  }
}