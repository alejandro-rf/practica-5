using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostAttackCommand : Command
{
    private float value;

    public BoostAttackCommand(Entity target, float value) : base(target)
    {
        this.value = value;
    }

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
