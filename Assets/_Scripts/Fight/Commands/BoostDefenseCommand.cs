using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDefenseCommand : Command
{
    private float value;

    public BoostDefenseCommand(Entity target, float value) : base(target)
    {
        this.value = value;
    }

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
