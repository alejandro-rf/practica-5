using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand : FightCommand
{
    private float value;
    FightCommandTypes type = FightCommandTypes.Heal;
    TargetTypes targets = TargetTypes.Friend;

    public HealCommand(Fighter entity, float value) : base(entity)
    {
        Type = type;
        PossibleTargets = TargetTypes.Friend;
        this.value = value;
    }

    public HealCommand() { Type = type; PossibleTargets = targets; }
    public override void Excecute()
    {
        (_target as Fighter).Heal(value);
    }

    public override void Undo()
    {
        (_target as Fighter).Heal(-value);
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
