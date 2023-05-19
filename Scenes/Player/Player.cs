using Godot;

public partial class Player : CharacterBody2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var input = GetMovementInput()
            .Normalized();

        MoveLocalX(input.X * (float) delta);
        MoveLocalY(input.Y * (float) delta);
    }

    /// NOT NORMALISED
    Vector2 GetMovementInput() =>
        new(Input.GetAxis("MoveLeft", "MoveRight"), Input.GetAxis("MoveDown", "MoveUp"));
}
