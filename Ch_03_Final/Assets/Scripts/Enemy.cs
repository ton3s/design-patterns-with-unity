using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPrototype
{
    IPrototype ShallowClone();
    IPrototype DeepClone();
}

public class Enemy : IPrototype
{
    public int Damage;
    public string Message;
    public string Name;
    public Item Item;

    public Enemy(int dmg, string msg, string name, Item item)
    {
        this.Damage = dmg;
        this.Message = msg;
        this.Name = name;
        this.Item = item;
    }

    public void Print()
    {
        Debug.LogFormat($"{Message}! {Name} has an {Item.Name} and can hit for {Damage} HP.");
    }

    public IPrototype DeepClone()
    {
        Enemy newPrototype = (Enemy)ShallowClone();
        newPrototype.Item = new Item(this.Item.Name);

        return newPrototype;
    }

    public IPrototype ShallowClone()
    {
        IPrototype newPrototype = null;

        try
        {
            newPrototype = (IPrototype)this.MemberwiseClone();
        }
        catch (Exception e)
        {
            Debug.LogError("Error cloning: " + e);
        }

        return newPrototype;
    }
}