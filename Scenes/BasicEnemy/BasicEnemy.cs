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

    /// Return normalised direction to player, or zero if player not found
    Vector2 GetDirectionToPlayer()
    {
        var playerNode = GetTree()
            .GetFirstNodeInGroup("player");

        if (playerNode is Player player) { return (player.GlobalPosition - GlobalPosition).Normalized(); }

        GD.PrintErr("E002: BasicEnemy could not find player");
        return Vector2.Zero;
    }
}
