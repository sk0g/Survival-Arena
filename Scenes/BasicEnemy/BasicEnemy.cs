using System;
using Godot;

public partial class BasicEnemy : CharacterBody2D
{
    [Export]
    float _movementSpeed = 50;

    public override void _Ready() { }

    public override void _Process(double delta)
    {
        Velocity = _movementSpeed * GetDirectionToPlayer();
        MoveAndSlide();
    }

    /// Return normalised direction to player, or throw an exception otherwise
    Vector2 GetDirectionToPlayer()
    {
        var player = GetTree().GetFirstNodeInGroup("player") as Player
         ?? throw new Exception("E002: BasicEnemy could not find player");

        return (player.GlobalPosition - GlobalPosition).Normalized();
    }
}
