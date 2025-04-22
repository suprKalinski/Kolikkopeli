using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 250;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 inputDir = Input.GetVector("LEFT", "RIGHT", "UP", "DOWN");

        if (inputDir != Vector2.Zero)
        {
            Velocity = inputDir.Normalized() * Speed;
        }
        else
        {
            Velocity = Vector2.Zero;
        }

        MoveAndSlide();
    }
}

