using System;
using System.Linq;
using Godot;

public partial class SwordAbilityController : Node
{
    Timer _abilityTimer;

    [Export]
    float _maxRange = 200f;

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

        var nearestEnemy = GetTree()
            .GetNodesInGroup("enemy")
            .OfType<Node2D>()
            .Select(enemy => new Tuple<Node2D, float>(enemy,
                enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition)))
            .Where(enemyAndDistance => enemyAndDistance.Item2 < Mathf.Pow(_maxRange, 2))
            .MinBy(enemyAndDistance => enemyAndDistance.Item2)
            ?.Item1;

        if (nearestEnemy is null)
        {
            GD.Print("SwordAbility: No nearby enemy found to attack");
            return;
        }

        var swordInstance = _swordAbility.Instantiate() as Node2D
         ?? throw new Exception("E004: SwordAbility could not instantiate");

        swordInstance.GlobalPosition = nearestEnemy.GlobalPosition;
        player.GetParent().AddChild(swordInstance);
    }
}
