using Godot;

public partial class Camera : Camera2D
{
    Player _player;

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

        GlobalPosition = _player.GlobalPosition;
    }

    void FindAndSetPlayer()
    {
        var foundNode = GetTree()
            .GetFirstNodeInGroup("player");

        if (foundNode is Player player) { _player = player; }
        else { GD.PrintErr("Camera could not find player"); }
    }
}
