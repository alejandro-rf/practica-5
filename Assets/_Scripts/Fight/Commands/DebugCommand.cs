using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommand : MonoBehaviour
{
    public Fighter fighter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var command = new AttackCommand(fighter, 50f);
            Invoker.AddCommand(command);

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            var command = new HealCommand(fighter, 3f);
            Invoker.AddCommand(command);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            var command = new BoostAttackCommand(fighter, 1f);
            Invoker.AddCommand(command);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            var command = new BoostDefenseCommand(fighter, 1f);
            Invoker.AddCommand(command);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            var command = new ShieldCommand(fighter, 5f);
            Invoker.AddCommand(command);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Invoker.Undo();
        }
    }
}
