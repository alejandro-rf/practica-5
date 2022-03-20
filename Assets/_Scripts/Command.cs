using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    protected Entity _target;
    public FightCommandTypes Type;
    public TargetTypes PossibleTargets;

    protected Command(Entity target)
    {
        _target = target;
    }

    public abstract void Excecute();
    public abstract void Undo();
}
