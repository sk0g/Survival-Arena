using System;
using Godot;

public partial class BasicEnemy : CharacterBody2D
{
    [Export]
    float _movementSpeed = 50;

    [Export]
    // On spawn, will set movement speed to be _movementSpeed +/- this value
    float _movementSpeedVariation = 5;

    RandomNumberGenerator _rng = new();

    public override void _Ready()
    {
        _movementSpeed += _rng.RandfRange(-_movementSpeedVariation, _movementSpeedVariation);
    }

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
