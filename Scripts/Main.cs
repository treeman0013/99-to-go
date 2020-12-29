using Godot;
using System;

public class Main : Spatial
{
	public Spatial room1;
	public KinematicBody player;
	public Node mapNode;
	public int globalSeed;
	public RandomNumberGenerator rng = new RandomNumberGenerator();
	public MapGenerator mapGenerator = new MapGenerator();

	public override void _Ready()
	{
		//instantiate objects
		room1 = (Spatial)ResourceLoader.Load<PackedScene>("res:///Scenes/Rooms/Room1.tscn").Instance();
		mapNode = (Node)ResourceLoader.Load<PackedScene>("res:///Scenes/Map.tscn").Instance();
		player = (KinematicBody)ResourceLoader.Load<PackedScene>("res:///Scenes/Player.tscn").Instance();

		//set up variables
		rng.Randomize();
		globalSeed = (int)rng.Randi();
		Spatial[] rooms = { (Spatial)room1 };

		//generate map
		mapGenerator.Generate(globalSeed, mapNode, rooms);
	}
}
