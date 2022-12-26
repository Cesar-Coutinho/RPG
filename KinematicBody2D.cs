//using Godot;
//using System;

//public class KinematicBody2D : Godot.KinematicBody2D
using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
	[Export] public int speed = 100;

	public Vector2 velocity = new Vector2();
	public string ultimoMov;


	private AnimatedSprite _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}

	public override void _Process(float _delta)
	{
		if (Input.IsActionPressed("ui_down"))
		{
			_animatedSprite.Play("AndandoParaBaixo");
			ultimoMov = "ui_up";
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			_animatedSprite.Play("AndandoParaTras");
			ultimoMov = "ui_down";
		}
		else if(Input.IsActionPressed("ui_right"))
		{
			_animatedSprite.Play("AndandoLadoDireito");
			ultimoMov = "ui_up";
		}
		else if(Input.IsActionPressed("ui_left"))
		{
			_animatedSprite.Play("AndandoLadoEsquerdo");
			ultimoMov = "ui_up";
		}
		else if(Input.IsActionPressed("ui_up"))	
		{
			_animatedSprite.Play("ParadoTras");
			ultimoMov = "ui_down";
		}
		else
		{
			if(ultimoMov == "ui_down")
			{
				_animatedSprite.Play("ParadoTras");
				Console.WriteLine("Tras");
			}
			else
			{
				_animatedSprite.Play("Parado");
				Console.WriteLine("Frente");
			}
		}
	}

	public void GetInput()
	{
		velocity = new Vector2();

		if (Input.IsActionPressed("ui_right"))
			velocity.x += 1;

		if (Input.IsActionPressed("ui_left"))
			velocity.x -= 1;

		if (Input.IsActionPressed("ui_down"))
			velocity.y += 1;
			

		if (Input.IsActionPressed("ui_up"))
			velocity.y -= 1;

		velocity = velocity.Normalized() * speed;
	}

	public override void _PhysicsProcess(float delta)
	{
		GetInput();
		velocity = MoveAndSlide(velocity);
	}
}
