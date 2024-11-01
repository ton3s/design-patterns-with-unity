using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PrefabSpawner : MonoBehaviour
{
	// 1
	public BaseEnemy OgrePrefab;
	public BaseEnemy AshKnightPrefab;
	private Factory<ICopy> factory = new Factory<ICopy>();
	// 2
	void Awake()
	{
		factory["Ogre"] = OgrePrefab;
		factory["Knight"] = AshKnightPrefab;
	}
	void Start()
	{
		// 3
		for (int i = 0; i < 10; i++)
		{
			// 4
			BaseEnemy clone = null;
			var random = Random.Range(1, 3);

			// 5
			switch (random)
			{
				case 1:
					clone = (BaseEnemy)factory["Ogre"].Copy(this.transform);
					break;
				case 2:
					clone = (BaseEnemy)factory["Knight"].Copy(this.transform);
					break;
			}
			// 6
			if (clone)
			{
				clone.Attack();
			}
		}
	}
}
