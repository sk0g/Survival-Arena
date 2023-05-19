using Godot;

public partial class Camera : Camera2D
{
    [Export(PropertyHint.Range, "-20,-1")]
    float _cameraSmoothing = -5f;

    Player _player;
    Vector2 _targetPosition = Vector2.Zero;

    public override void _Ready()
    {
        MakeCurrent();
        FindAndSetPlayer();
    }

    public override void _Process(double delta)
    {
        if (_player is null)
        {
            FindAndSetPlayer();
            return;
        }

        GlobalPosition = GlobalPosition.Lerp(_player.GlobalPosition, SmoothLerpValue(delta));
    }

    void FindAndSetPlayer()
    {
        var foundNode = GetTree()
            .GetFirstNodeInGroup("player");

        if (foundNode is Player player) { _player = player; }
        else { GD.PrintErr("E001: Camera could not find player"); }
    }

    float SmoothLerpValue(double delta) => 1f - Mathf.Exp((float) delta * _cameraSmoothing);
}
