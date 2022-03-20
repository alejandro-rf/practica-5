using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCommand : Command
{
    private float value;

    public ShieldCommand(Entity target, float value) : base(target)
    {
        this.value = value;
    }

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
