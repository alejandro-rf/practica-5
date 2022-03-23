using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostAttackCommand : FightCommand
{
    private float value;
    FightCommandTypes type = FightCommandTypes.BoostAttack;
    TargetTypes targets = TargetTypes.Self;

    public BoostAttackCommand(Entity target, float value) : base(target)
    {
        Type = type;
        PossibleTargets = TargetTypes.Self;
        this.value = value;
    }

    public BoostAttackCommand() { Type = type; PossibleTargets = targets; }

    public override void Excecute()
    {
        (_target as Fighter).AddAttackPermanent(value);
    }

    public override void Undo()
    {
        (_target as Fighter).AddAttackPermanent(-value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
