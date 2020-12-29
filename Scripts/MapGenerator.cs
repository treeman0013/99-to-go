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

        map.AddChild(rooms[0]);
        
        //generate map
        for(int x = 0; x < mapX; x++)
        {
            for(int z = 0; z < mapZ; z++)
            {
                map.AddChild(rooms[0].Duplicate());
                rooms[0].Translation = new Vector3(x * 20, 0, z * 20);
                GD.Print($"Room Created at x:{x} and z:{z}");
            }
        }

        GD.Print($"RoomX: {mapX} RoomY: {mapZ}");
        return map;
    }
}
