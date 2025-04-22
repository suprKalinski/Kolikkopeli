using Godot;
using System;

public partial class Coin : Area2D
{
    [Signal]
    public delegate void CollectedEventHandler();
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;

    }
    public void Collect()
    {
        EmitSignal(SignalName.Collected);
        QueueFree();
    }
    private void OnBodyEntered(Node2D body)
    {
        if (body is Player)
        {
            Collect();
        }
    }
}
