using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;

public class CommandFactory
{
    private Dictionary<string, Type> _commandByName;
    public CommandFactory()
    {
        //Look at (assembly) where ICommand is registered and get all classes that are ICommand
        //.Where -> Filter: is not an interface && implements ICommand
        var commandTypes = Assembly.GetAssembly(typeof(ICommand)).GetTypes()
            .Where(x => !x.IsInterface && typeof(ICommand).IsAssignableFrom(x));

        _commandByName = new Dictionary<string, Type>();

        foreach(var commandType in commandTypes)
        {
            //Create instance of gun or sword so that we can get value of Name attribute
            var tempCommand  = Activator.CreateInstance(commandType);
            _commandByName.Add(((ICommand)tempCommand).Name, commandType);
        }
    }

    public ICommand GetWeapon(string commandType)
    {
        if (_commandByName.ContainsKey(commandType))
        {
            return Activator.CreateInstance(_commandByName[commandType]) as ICommand;
        }
        Debug.LogError("No fem" + commandType);
        return null;
    }

    public string[] GetAllNames()
    {
        return _commandByName.Keys.ToArray();
    }
}
