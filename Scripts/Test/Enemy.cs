using Godot;
using System;

public class Enemy : Sprite3D
{
  public int animCol = 0;
  public Camera camera;
  public override void _Ready()
  {
	camera = GetNode<Camera>("../Player/Head/Camera");
  }
  public override void _Process(float delta)
  {
	var pForward = -camera.GlobalTransform.basis.z;
	var forward = GlobalTransform.basis.z;
	var left = GlobalTransform.basis.x;

	var leftDot = left.Dot(pForward);
	var forwardDot = forward.Dot(pForward);

	var row = 0;
	FlipH = false;

	if (forwardDot < -0.85)
	{
	  row = 0; //front sprite
	}
	else if (forwardDot > 0.85)
	{
	  row = 4;
	}
	else
	{
	  FlipH = leftDot > 0;
	  if (Math.Abs(forwardDot) < 0.3)
	  {
		row = 2;
	  }
	  else if (forwardDot < 0)
	  {
		row = 1;
	  }
	  else
	  {
		row = 3;
	  }
	}
	Frame = animCol + row * 4;
  }
}
