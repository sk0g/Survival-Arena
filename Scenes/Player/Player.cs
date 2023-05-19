using Godot;

public partial class Player : CharacterBody2D
{
    [Export]
    float _movementSpeed = 50f;

    public override void _Ready() { }

    public override void _Process(double delta)
    {
        var input = GetMovementInput()
            .Normalized();

        MoveLocalX(input.X * _movementSpeed * (float) delta);
        MoveLocalY(input.Y * _movementSpeed * (float) delta);
    }

    /// NOT NORMALISED
    Vector2 GetMovementInput() =>
        new(Input.GetAxis("MoveLeft", "MoveRight"), Input.GetAxis("MoveDown", "MoveUp"));
}
