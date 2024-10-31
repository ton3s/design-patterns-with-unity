using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataSpawner : MonoBehaviour
{
	void Start()
	{
		// 1
		Factory<IPrototype> factory = new Factory<IPrototype>();
		// 2
		factory["Ogre"] = new Enemy(10, "RAWR", "Ogre", new Item("Poison dart"));
		factory["Knight"] = new Enemy(15, "To Arms!", "Ash Knight", new Item("Shuriken"));
		// 3
		Enemy ogre1Prototype = (Enemy)factory["Ogre"].DeepClone();
		Enemy ogre2Prototype = (Enemy)factory["Ogre"].DeepClone();
		ogre2Prototype.Name = "Ogre 2";
		Enemy ogre3Prototype = (Enemy)factory["Ogre"].DeepClone();
		ogre3Prototype.Name = "Ogre 3";

		Enemy knightPrototye = (Enemy)factory["Knight"].DeepClone();

		// 4
		if (ogre1Prototype is Enemy ogreEnemy)
		{
			ogre1Prototype.Print();
			ogre2Prototype.Print();
			ogre3Prototype.Print();
		}
		if (knightPrototye is Enemy knightEnemy)
		{
			knightEnemy.Print();
		}
	}

}
