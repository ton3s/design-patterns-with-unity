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
	// 2
	public Enemy(int dmg, string msg, string name, Item item)
	{
		this.Damage = dmg;
		this.Message = msg;
		this.Name = name;
		// 2
		this.Item = item;
	}
	public void Print()
	{
		// 3
		Debug.LogFormat($"{Message}! {Name} has a {Item.Name} and can hit for {Damage}  HP.");
	}

	public IPrototype ShallowClone()
	{
		// 1
		IPrototype newPrototype = null;
		// 2
		try
		{
			// 3
			newPrototype = (IPrototype)this.MemberwiseClone();
		}
		// 4
		catch (Exception e)
		{
			Debug.LogError("Error cloning: " + e);
		}
		// 5
		return newPrototype;
	}


	public IPrototype DeepClone()
	{
		// 1
		Enemy newPrototype = (Enemy)ShallowClone();
		// 2
		newPrototype.Item = new Item(this.Item.Name);
		// 3
		return newPrototype;
	}

}
