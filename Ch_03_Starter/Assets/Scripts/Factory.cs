using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1
public class Factory<T>
{
	// 2
	private Dictionary<string, T> objects = new Dictionary<string, T>();
	// 3
	public T this[string key]
	{
		// 4
		get
		{
			if (objects.ContainsKey(key))
			{
				return objects[key];
			}
			else
			{
				throw new KeyNotFoundException("Key not found: " + key);
			}
		}

		// 5
		set
		{
			if (objects.ContainsKey(key))
			{
				objects[key] = value;
			}
			else
			{
				objects.Add(key, value);
			}
		}
	}
}
