using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;

public class CommandFactory
{
    private Dictionary<FightCommandTypes, Type> _commandByName;
    public CommandFactory()
    {
        var commandTypes = Assembly.GetAssembly(typeof(FightCommand)).GetTypes()
            .Where(x => !x.IsInterface && typeof(FightCommand).IsAssignableFrom(x));

        _commandByName = new Dictionary<FightCommandTypes, Type>();

        foreach (var commandType in commandTypes)
        {
            var tempCommand = Activator.CreateInstance(commandType);
            _commandByName.Add(((FightCommand)tempCommand).Type, commandType);
        }
    }

    public FightCommand GetCommand(FightCommandTypes commandType)
    {
        if (_commandByName.ContainsKey(commandType))
        {
            return Activator.CreateInstance(_commandByName[commandType]) as FightCommand;
        }
        Debug.LogError("No fem" + commandType);
        return null;
    }

    public FightCommandTypes[] GetAllCommands()
    {
        return _commandByName.Keys.ToArray();
    }

    public Dictionary<FightCommandTypes, Type> GetCommands()
    {
        return _commandByName;
    }
}
