using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    private float value = 5f;
    
    public AttackCommand(Fighter entity, float value) : base(entity)
    {
        Type = FightCommandTypes.Attack;
        PossibleTargets = TargetTypes.Enemy;
        this.value = value;
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