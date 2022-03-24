using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCommand : FightCommand
{
    private float value = 5;
    FightCommandTypes type = FightCommandTypes.Shield;
    TargetTypes targets = TargetTypes.FriendNotSelf;

    public ShieldCommand(Entity target, float value = 5) : base(target)
    {
        Type = type;
        PossibleTargets = TargetTypes.FriendNotSelf;
        this.value = value;
    }

    public ShieldCommand() { Type = type; PossibleTargets = targets; }
    public override void Excecute()
    {
        (_target as Fighter).AddDefense(value);
    }

    public override void Undo()
    {
        (_target as Fighter).AddDefense(-value);
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
