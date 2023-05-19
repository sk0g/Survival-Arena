using Godot;

public partial class Player : CharacterBody2D
{
    [Export]
    float _movementSpeed = 10_000f;

    public override void _Ready() { }

    public override void _Process(double delta)
    {
        var input = GetMovementInput()
            .Normalized();

        Velocity = input * _movementSpeed * (float) delta;
        MoveAndSlide();
    }

    /// NOT NORMALISED
    Vector2 GetMovementInput() =>
        new(Input.GetAxis("MoveLeft", "MoveRight"), Input.GetAxis("MoveUp", "MoveDown"));
}
