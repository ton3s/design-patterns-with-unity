using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;    
using System.Reflection;  
using System.Linq;    

public class ReflectionFactory
{
    public GameObject Spawner { get; protected set; }

    Dictionary<string, Type> _items = new Dictionary<string, Type>();
    public Dictionary<string, Type> Items    
    {
        get { return _items; }    
    }

    public ReflectionFactory()    
    {
        Spawner = new GameObject();
        Spawner.name = "Reflection Factory";

        var itemTypes = Assembly.GetAssembly(typeof(IItem)).GetTypes();
        var filteredItems = itemTypes.Where(item => !item.IsInterface &&
                                            typeof(IItem).IsAssignableFrom(item));


        foreach (var type in filteredItems)    
        {
            _items.Add(type.Name, type);
        }
    }

    public IItem Create(string itemName, GameObject model, Vector3 position)    
    {
        if (_items.ContainsKey(itemName))    
        {
            Type type = _items[itemName];
            var obj = GameObject.Instantiate(model);
            var item = obj.AddComponent(type) as IItem;

            obj.transform.position = position;
            obj.transform.SetParent(Spawner.transform);

            return obj.GetComponent(type) as IItem;
        }

        return null;    
    }
}