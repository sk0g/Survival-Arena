using System;
using Godot;

public partial class SwordAbilityController : Node
{
    Timer _abilityTimer;

    [Export]
    PackedScene _swordAbility;

    public override void _Ready()
    {
        _abilityTimer = GetNode<Timer>("AbilityTimer");
        _abilityTimer.Timeout += HandleAbilityTimer;
    }

    public override void _Process(double delta) { }

    void HandleAbilityTimer()
    {
        var player = GetTree().GetFirstNodeInGroup("player") as Player
         ?? throw new Exception("E003: SwordAbility did not find player");

        var swordInstance = _swordAbility.Instantiate() as Node2D
         ?? throw new Exception("E004: SwordAbility could not instantiate");

        swordInstance.GlobalPosition = player.GlobalPosition;
        player.GetParent().AddChild(swordInstance);
    }
}
