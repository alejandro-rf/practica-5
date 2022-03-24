using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDefenseCommand : FightCommand
{
    private float value = 1;
    FightCommandTypes type = FightCommandTypes.BoostDefense;
    TargetTypes targets = TargetTypes.Self;

    public BoostDefenseCommand(Entity target, float value = 1) : base(target)
    {
        Type = type;
        PossibleTargets = TargetTypes.Self;
        this.value = value;
    }

    public BoostDefenseCommand() { Type = type; PossibleTargets = targets; }
    public override void Excecute()
    {
        (_target as Fighter).AddDefensePermanent(value);
    }

    public override void Undo()
    {
        (_target as Fighter).AddDefensePermanent(-value);
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
