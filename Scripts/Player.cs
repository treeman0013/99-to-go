using Godot;
using System;

public class Player : KinematicBody
{
	public int speed = 10;
	public float acceleration = 5f;
	public float gravity = 0.98f;
	public float jumpPower = 30f;
	public float mouseSensetivity = 0.3f;
	public Vector3 velocity;
	public Spatial head;
	public Camera camera;

	public override void _Ready()
	{
		head = GetNode<Spatial>("Head");
		camera = GetNode<Camera>("Head/Camera");
		Input.SetMouseMode(Input.MouseMode.Captured);
	}

	public override void _PhysicsProcess(float delta)
	{
		Basis headBasis = head.GlobalTransform.basis;

		Vector3 direction = new Vector3();

		if(Input.IsActionPressed("MoveUp"))
		{
			direction -= headBasis.z;
		}
		else if(Input.IsActionPressed("MoveDown"))
		{
			direction += headBasis.z;
		}
		if(Input.IsActionPressed("MoveLeft"))
		{
			direction -= headBasis.x;
		}
		else if(Input.IsActionPressed("MoveRight"))
		{
			direction += headBasis.x;
		}

		if(Input.IsActionJustPressed("Escape"))
		{
			Input.SetMouseMode(Input.MouseMode.Visible);
		}

		direction = direction.Normalized();

		velocity = velocity.LinearInterpolate(direction * speed, acceleration * delta);

		velocity = MoveAndSlide(velocity);
	}

	public override void _Input(InputEvent @event)
	{
		if(@event is InputEventMouseMotion e)
		{
			head.RotateY(Mathf.Deg2Rad(-e.Relative.x * mouseSensetivity));
		}
	}
}
