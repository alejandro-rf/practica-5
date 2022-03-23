using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    protected Entity _target;

    public Command(Entity target)
    {
        _target = target;
    }

    public Command() { }

    public abstract void Excecute();
    public abstract void Undo();
}
