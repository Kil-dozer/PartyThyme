using System;
using System.Collections.Generic;

namespace PartyThyme
{
  public class Plant
  {
    // What it is
    public int ID { get; set; }
    // When collected
    public string Species { get; set; }
    // What it eats
    public string PlantLocation { get; set; }
    public DateTime PlanetedDate { get; set; }
    public DateTime LastWateredDate { get; set; }
    public int LightLevelNeeded { get; set; }
    public int WaterNeeded { get; set; }

  }
}
