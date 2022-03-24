using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDefenseCommand : FightCommand
{
    private float value = 3f;
    FightCommandTypes type = FightCommandTypes.DebuffDefense;
    TargetTypes targets = TargetTypes.Enemy;

    public DebuffDefenseCommand(Entity target, float value = 3f) : base(target)
    {
        Type = type;
        PossibleTargets = TargetTypes.Enemy;
        this.value = value;
    }

    public DebuffDefenseCommand() { Type = type; PossibleTargets = targets; }

    public override void Excecute()
    {
        (_target as Fighter).SubtractDefensePermanent(value);
    }

    public override void Undo()
    {
        (_target as Fighter).SubtractDefensePermanent(-value);
    }
}
