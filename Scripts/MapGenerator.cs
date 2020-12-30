using Godot;
using System;

public class MapGenerator
{

  RandomNumberGenerator rng = new RandomNumberGenerator();
  public Node Generate(int seed, Node map, Spatial[] rooms)
  {
    //set up seed and vars
    rng.Seed = (ulong)seed;
    int mapX = rng.RandiRange(5, 15);
    int mapZ = rng.RandiRange(4, 12);

    //generate map
    int ranX = rng.RandiRange(1, mapX - 1), ranZ = rng.RandiRange(1, mapZ - 1);

    Spatial mainRoom = (Spatial)rooms[0].Duplicate();
    mainRoom.Name = "Room_" + ranX + "," + ranZ;
    map.AddChild(mainRoom);

    map.GetNode<Spatial>("Room_" + ranX + "," + ranZ).Translation = new Vector3(ranX * 20, 0, ranZ * 20);

    GD.Print($"{map.GetChildren()[0]}");
    return map;
  }
}
