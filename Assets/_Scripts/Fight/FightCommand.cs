using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCommand : Command
{
    public FightCommandTypes Type;
    public TargetTypes PossibleTargets;

    public FightCommand(Entity target) : base(target)
    {
        _target = target;
    }

    public FightCommand() { Type = FightCommandTypes.None; }

    public override void Excecute()
    {
        
    }

    public override void Undo()
    {
        
    }
}
