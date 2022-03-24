using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : FightCommand
{
    private float value = 5f;
    FightCommandTypes type = FightCommandTypes.Attack;
    TargetTypes targets = TargetTypes.Enemy;

    public AttackCommand(Fighter entity, float value = 5f) : base(entity)
    {
        Type = type;
        PossibleTargets = TargetTypes.Enemy;
        this.value = value;
    }

    public AttackCommand()
    {
        Type = type;
        PossibleTargets = targets;
    }

    public override void Excecute()
    {
        (_target as Fighter).TakeDamage(value);
    }

    public override void Undo()
    {
        (_target as Fighter).UndoDamage(-value);
    }
}