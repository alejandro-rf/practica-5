using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EntityManager EntityManager;
    public ActionButtonController ActionButtonController;
    public ChooseTarget TargetChooser;
    public Invoker Invoker;
    public StatsUI Stats;
    private CommandFactory _factory;

    // Start is called before the first frame update
    void Start()
    {
        _factory = new CommandFactory();

        StartBattle();      

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextTurn();
        }
    }

    void StartBattle()
    {
        ShowCurrentFighterStats();
    }

    public void DoAction(FightCommandTypes commandType)
    {
        ChooseTarget(_factory.GetCommand(commandType));
    }

    private void ChooseTarget(FightCommand _currentCommand)
    {
        var targetTypes = _currentCommand.PossibleTargets;

        Entity[] possibleTargets;

        switch (targetTypes)
        {
            case TargetTypes.Enemy:
                possibleTargets = EntityManager.Enemies;
                break;
            case TargetTypes.Friend:
                possibleTargets = EntityManager.Friends;
                break;
            case TargetTypes.FriendNotSelf:
                possibleTargets = EntityManager.FriendsNotSelf;
                break;
            case TargetTypes.Self:
                possibleTargets = new Entity[1];
                possibleTargets[0] = EntityManager.ActiveEntity;
                break;

            default:
                possibleTargets = EntityManager.Enemies;
                break;
        }
        ActionButtonController.ChooseTarget(EntityManager.ActiveEntity);
        TargetChooser.StartChoose(possibleTargets);
    }
    
    private void DoAction(Entity actor, Entity target, FightCommandTypes type)
    {
        //Com sé quin tipus de command arriba per a generar-lo
        var command = _factory.GetCommand(type);
        Invoker.AddCommand(command);
    }

    private void Undo()
    {
        
    }


    public void NextTurn()
    {
        EntityManager.SetNextEntity();
        //Debug.Log(EntityManager.ActiveEntity);
        ActionButtonController.UpdateButtons();

        ShowCurrentFighterStats();
    }

    private void ShowCurrentFighterStats()
    {
        var fighter = EntityManager.ActiveEntity.GetComponent<Fighter>();
        Stats.SetEntity(fighter);
    }

    internal void TargetChosen(ISelectable entity)
    {
        if (!(entity is Entity))
        {
            Debug.LogError("Selected is not entity");
            return;
        }
    }
}
