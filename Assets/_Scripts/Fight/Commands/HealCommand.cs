﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand : Command
{
    private float value;

    public HealCommand(Fighter entity, float value) : base(entity)
    {
        this.value = value;
    }

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
